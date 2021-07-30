using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class PoetBot : Robot
    {
        public PoetBot(): base()
        {

        }
        public PoetBot(DateTime creationDate): base(creationDate)
        {

        }
        public string FavoriteAuthor { get; set; }
        public string FavoritePoem { get; set; }
        public override string Sing()
        {
            return
            @"A fost odata ca-n povesti,
            A fost ca niciodata,
            Din rude mari imparatesti,
            O prea frumoasa fata.";
        }
        public string Sing(string poem)
        {
            return poem;
        }
    }
}
