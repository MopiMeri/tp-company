using System;
namespace GestionBourget
{
    public class Emplacement{

        private string hall;
        private int parcelle;
        private int surface;

        public string Hall{
            get{ return hall; }
            set{ hall = value; }
        }
        public int Parcelle{
            get{ return parcelle; }
            set{ parcelle = value; }
        }

        public int Surface{
            get{ return surface; }
            set{ surface = value; }
        }

        public Emplacement(){
        }

        public Emplacement(string hall, int parcelle, int surface){
            this.hall = hall;
            this.parcelle = parcelle;
            this.surface = surface;
        }
    }
}
