using Gevangenis.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Gevangenis.Models.Entity
{
    public class Cell : BaseAuditableEntity
    {
        public int Capacity { get; set; } = 1;
        public bool IsIsolationCell { get; set; } = false;
        [Required]
        public Prison Prison { get; set; } = new Prison();
        public List<Prisoner> Prisoners { get; private set; } = new List<Prisoner>();

        public Cell(int capacity, bool isIsolationCell, Prison prison, List<Prisoner> prisoners)
        {
            Capacity = capacity;
            IsIsolationCell = isIsolationCell;
            Prison = prison;
            Prisoners = prisoners;
        }

        public Cell(int capacity, Prison prison)
        {
            Capacity = capacity;
            Prison = prison;
        }

        public Cell(Prison prison)
        {
            Prison = prison;
        }

        public Cell()
        {

        }

        public void TryAddPrisoners(List<Prisoner> prisoners)
        {
            foreach (var prisoner in prisoners)
            {
                TryAddPrisoner(prisoner);
            }
        }

        public void TryAddPrisoner(Prisoner prisoner)
        {
            if (prisoner.IsCompatibleCellMateWithList(Prisoners))
            {
                Prisoners.Add(prisoner);
            }
            else
            {
                throw new InvalidOperationException("Prisoner your are trying to add to cell are incompatible");
            }
        }

        public void UpdatePrisoners(List<Prisoner> newPrisoners)
        {
            var oldPrisonersList = Prisoners;
            foreach (var newPrisoner in newPrisoners)
            {
                if (oldPrisonersList.Contains(newPrisoner))
                {
                    oldPrisonersList.Remove(newPrisoner);
                    newPrisoners.Remove(newPrisoner);
                }
            }
            foreach (var oldPrisoner in oldPrisonersList)
                Prisoners.Remove(oldPrisoner);

            TryAddPrisoners(newPrisoners);
        }
    }
}
