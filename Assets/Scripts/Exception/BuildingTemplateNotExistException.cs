using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Exception
{
    internal class BuildingTemplateNotExistException : System.Exception
    {
        public override string Message => "Building template handler doesn't exist for config value!";
    }
}
