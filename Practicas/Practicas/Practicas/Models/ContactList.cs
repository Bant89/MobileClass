using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;



namespace Practicas.Models
{

    class ContactList
    {
        public ObservableCollection<Contact> List { get; set; }


        public ContactList()
        {
           this.List = new ObservableCollection<Contact>
            {
                new Contact("Juan", "Perez", 8291340099),
                new Contact("Sofia", "Perez", 8291340099)
            };
        }

    }
}
