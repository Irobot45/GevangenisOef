using Gevangenis.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gevangenis.Models.Entity
{
    public enum PrisonerType
    {
        lowLevel,
        mediumLevel,
        highLevel,
        kevinLevel
    }

    public class Prisoner : BaseAuditableEntity
    {
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnterPrisonDateTime { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime EndDateTimeSentence { get; set; } = DateTime.MaxValue;
        [DataType(DataType.Date)]
        public DateTime? LeavePrisonDateTime { get; set; }
        public virtual Prison? Prison { get; set; }
        public virtual Cell? Cell { get; set; }
        [Column(TypeName = "prisonerType")]
        public PrisonerType PrisonerType { get; set; } = PrisonerType.lowLevel;
        public bool IsMale = true;

        public Prisoner()
        {

        }

        public Prisoner(string name)
        {
            Name = name;
        }

        public Prisoner(string name, Prison prison)
        {
            Name = name;
            Prison = prison;
        }

        public bool IsCompatibleCellMateWithList(List<Prisoner> cellMates)
        {
            foreach (var cellMate in cellMates)
            {
                if (!IsCompatibleCellMateWith(cellMate))
                    return false;
            }
            return true;
        }
        public bool IsCompatibleCellMateWith(Prisoner cellMate)
        {
            IncompatiblePrisonerTypeValidator validator = new IncompatiblePrisonerTypeValidator();
            return validator.IsCompatibleCellMateWith(this, cellMate);
        }
    }
}
