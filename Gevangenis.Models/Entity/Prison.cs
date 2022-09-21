using Gevangenis.Models.Base;

namespace Gevangenis.Models.Entity
{
    public class Prison : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public int Capacity { get; set; } = 0;
        public int AmountPrisoners { get; set; } = 0;
        public List<Cell> Cells { get; private set; } = new List<Cell>();

        public List<Prisoner> GetPrisoners()
        {
            List<Prisoner> prisoners = new List<Prisoner>();
            foreach (var cell in Cells)
            {
                prisoners.AddRange(cell.Prisoners);
            }
            return prisoners;
        }

        public Prison()
        {

        }

        public Prison(string name)
        {
            Name = name;
        }

        public void AddCells(List<Cell> cells)
        {
            foreach (var cell in cells)
                AddCell(cell);
        }

        public void AddCell(Cell cell)
        {
            this.Cells.Add(cell);
            this.Capacity += cell.Capacity;
        }

        public void RemoveCells(List<Cell> cells)
        {
            foreach (var cell in cells)
                RemoveCell(cell);
        }

        public void RemoveCell(Cell cell)
        {
            this.Cells.Remove(cell);
            this.Capacity -= cell.Capacity;
        }

        public void UpdateCells(List<Cell> cells)
        {
            var oldCells = this.Cells;
            foreach (var cell in cells)
            {
                if (oldCells.Contains(cell))
                {
                    oldCells.Remove(cell);
                }
                else
                {
                    AddCell(cell);
                }
            }
            RemoveCells(oldCells);
        }
    }
}
