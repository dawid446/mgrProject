using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Interfaces
{
    public interface IGenerationValueServices
    {

        void generationMain(int count, string table);
    }
}
