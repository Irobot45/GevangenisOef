using Gevangenis.Models.Entity;

namespace Gevangenis.Models
{
    internal class IncompatiblePrisonerTypeValidator
    {
        private readonly List<PrisonerType> _incompatibleWithLowLevel = new List<PrisonerType>()
        { PrisonerType.kevinLevel};

        private readonly List<PrisonerType> _incompatibleWithMediumLevel = new List<PrisonerType>()
        { PrisonerType.kevinLevel};

        private readonly List<PrisonerType> _incompatibleWithHighLevel = new List<PrisonerType>()
        { PrisonerType.kevinLevel};

        private readonly List<PrisonerType> _incompatibleWithKevinLevel = new List<PrisonerType>()
        { PrisonerType.lowLevel, PrisonerType.mediumLevel, PrisonerType.highLevel};

        public virtual bool IsCompatibleCellMateWith(Prisoner prisoner, Prisoner cellMate)
        {
            List<PrisonerType> incompatibleList = new List<PrisonerType>();
            if (prisoner.IsMale != cellMate.IsMale)
                return false;
            switch (prisoner.PrisonerType)
            {
                case PrisonerType.lowLevel:
                    incompatibleList = _incompatibleWithLowLevel;
                    break;
                case PrisonerType.mediumLevel:
                    incompatibleList = _incompatibleWithMediumLevel;
                    break;
                case PrisonerType.highLevel:
                    incompatibleList = _incompatibleWithHighLevel;
                    break;
                case PrisonerType.kevinLevel:
                    incompatibleList = _incompatibleWithKevinLevel;
                    break;
            }
            foreach (var incompatibleType in incompatibleList)
            {
                if (cellMate.PrisonerType == incompatibleType)
                    return false;
            }
            return true;
        }
    }
}
