using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesExample
{
    interface IManager : IWorker //Рядко 1 интерфейс наследява друг не се прави често. Поддържай малки интерфейси, като класа е добре да наследява и двата
        //а не всички данни в един. IWorker, IManager вместо всичко в IManager
    {
        public List<IManager> Team { get; set; }
    }
}
