using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public enum Evenement
    {
        SCAN_ARTICLE,
        POSER_BALANCE,
        ENLEVER_BALANCE,
        PAYER,
        RESET,
        SAISIEQUANTITE
    }
}
