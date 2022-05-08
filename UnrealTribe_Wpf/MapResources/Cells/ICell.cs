namespace UnrealTribe.MapResources
{
    public interface ICell
    {
        CellTypes CellType { get; }
        bool IsAvaible { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void ChangeCellType(CellTypes type);
        void TransformTo(CellTypes type);
        void TransformToHidden();
    }
}