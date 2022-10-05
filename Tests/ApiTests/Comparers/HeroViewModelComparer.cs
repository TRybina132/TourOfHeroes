using Presentation.ViewModels.Hero;
using System.Diagnostics.CodeAnalysis;

namespace ApiTests.Comparers
{
    public class HeroViewModelComparer : IEqualityComparer<HeroViewModel?>
    {
        public bool Equals(HeroViewModel? x, HeroViewModel? y) =>
            x?.Id == y?.Id 
            && x?.Name == y?.Name
            && (x?.UserId == y?.UserId);

        public int GetHashCode([DisallowNull] HeroViewModel obj) =>
            obj.Id;
    }
}
