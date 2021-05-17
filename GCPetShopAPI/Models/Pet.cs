using System;
using System.Collections.Generic;

#nullable disable

namespace GCPetShopAPI
{
    public partial class Pet
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string FurColor { get; set; }
        public int? Age { get; set; }
    }
}
