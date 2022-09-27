using GeometryGym.Ifc;

var db = new DatabaseIfc(ReleaseVersion.IFC4X1);



var facility = new IfcFacility(db, "My Facility")
{
    Description = "Just another facility",
};

var bridge = new IfcBridge(facility, "My Bridge", null, null)
{
    Description = "Just another bridge"
};


var project = new IfcProject(facility, "My Project", IfcUnitAssignment.Length.Metre);
{
};


var foundations = new IfcBridgePart(
    bridge, null, null
);

var name = "Pile Cap";
var length = 2.0;
var width = 2.0;
var depth = 2.0;

IfcMaterial material = new IfcMaterial(db, "Concrete")
{
};

IfcFootingType footingType = new IfcFootingType(db, name, IfcFootingTypeEnum.PAD_FOOTING)
{
    MaterialSelect = material,
};

IfcRectangleProfileDef rect = new IfcRectangleProfileDef(db, "rect", length, width);
IfcExtrudedAreaSolid extrusion = new IfcExtrudedAreaSolid(rect, new IfcAxis2Placement3D(new IfcCartesianPoint(db, 0, 0, 0)), new IfcDirection(db, 0, 0, 1), depth);

IfcProductDefinitionShape productRep = new IfcProductDefinitionShape(new IfcShapeRepresentation(extrusion));
IfcShapeRepresentation shapeRep = new(extrusion);

footingType.RepresentationMaps.Add(
    new IfcRepresentationMap(
        db.Factory.XYPlanePlacement,
        shapeRep
    )
);

IfcFooting footing = new(
    foundations,
    null,
    productRep
    )
{
    PredefinedType = IfcFootingTypeEnum.PAD_FOOTING,
    ObjectType = name
};

db.WriteFile("IFC4X1_testBridge.ifc");