using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPatternClasses
{

    public interface IIterator
    {
        bool HasNext();
        MenuItem Next();
    }
}
