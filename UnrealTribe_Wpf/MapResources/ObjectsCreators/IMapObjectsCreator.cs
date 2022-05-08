namespace UnrealTribe.MapResources
{
    public interface IMapObjectsCreator
    {
        public Cell[,] Cells { get; }
        int MinObjectLength { get; set; }

        Cell ChooseRandomCell();
        void CreateObjects(int objectsCount);
    }
}