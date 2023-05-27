using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomegkozlekedes_OEP_Beadando
{
    public class Company
    {
        //feladat nem nagyon kérte hogy ő csináljon bármit is. inkább csak azért van hogy lehessen majd a jövőben upgradelni.
        //beolvasásnál előjött egy ilyen probléma ugyhogy:
        public string name;

        public Company(string name) { this.name = name; }
        public string GetName() { return name; }
    }
}
