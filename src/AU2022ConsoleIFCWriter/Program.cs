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
var length = 1.2;
var width = 2.4;
var depth = 4.8;

IfcMaterial material = new IfcMaterial(db, "Concrete")
{
};

IfcFootingType footingType = new IfcFootingType(db, name, IfcFootingTypeEnum.PAD_FOOTING)
{
    MaterialSelect = material,
};

IfcRectangleProfileDef rect = new IfcRectangleProfileDef(db, "rect", length, width);
// IfcProductDefinitionShape rectProduct = new IfcProductDefinitionShape(new IfcShapeRepresentation(rect, ShapeRepresentationType.Curve2D));
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

//IfcLine line = new IfcLine(
//    new IfcCartesianPoint(db, 0, 0, 0),
//    new IfcVector(new IfcDirection(db, 1, 0), 10.0)
//);

//IfcSectionedSolidHorizontal sec = new IfcSectionedSolidHorizontal(
//    line,
//    new List<IfcProfileDef> { rect, rect, rect },
//    new List<IfcAxis2PlacementLinear> {
//        new IfcAxis2PlacementLinear(new IfcPointByDistanceExpression(0.0, line)),
//        new IfcAxis2PlacementLinear(new IfcPointByDistanceExpression(5.0, line)),
//        new IfcAxis2PlacementLinear(new IfcPointByDistanceExpression(10.0, line)) },
//    true
//);

//IfcBeam beam = new(foundations, null, new IfcProductDefinitionShape(new IfcShapeRepresentation(sec)))
//{
//    PredefinedType = IfcBeamTypeEnum.BEAM
//};


db.WriteFile("IFC4X1_testBridge.ifc");