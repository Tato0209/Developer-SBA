using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CsBussinesPartner  //Socio de Negocio
    {
        public string CardCode { get; set; } //Codigo de Socio de Negocio
        public string CardName { get; set; }
        public string CardType  { get; set; }
        public string LicTradNum  { get; set; }
        public int GroupCode { get; set; }
        public string U_C2410_P001 { get; set; }
        public string U_C2410_P002 { get; set; }
       
        public List<csAddress> listAddress = new List<csAddress>();  //List of Address // Inicializar en el constructor

        public List<csContacts> listContacts = new List<csContacts>(); //List of Contacts // Inicializar en el constructor
    }

    public class csAddress //Direcciones
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string AdresType { get; set; }
    }

    public class csContacts //Contactos
    {
        public int InternalCode { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Cellolar { get; set; } 
    }
}