using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    public record BookIdentifier(string name, string author);

    public record JournalIdentifier(string name, int editionNumber);
}
