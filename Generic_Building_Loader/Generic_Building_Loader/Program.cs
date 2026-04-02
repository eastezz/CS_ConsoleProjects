public class GenericBuildingLoader
{
    static void Main()
    {
        BuildingLoader b = new BuildingLoader("YourPath\\Test.txt");
        b.ReadFile();
        b.NewBuilding.GetBuildingInfo();
        
    }
}