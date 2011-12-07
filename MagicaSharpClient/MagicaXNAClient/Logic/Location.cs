using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient
{
    class Location
    {
        public Location(LocationType type)
        {
            // Количество вариантов каждой декорации.
            var variations = new Dictionary<string, int>();
            variations["mushroom"] = 1;
            variationCount = variations;

            type.createBackground();

            this.type = type;
        }
        /*void createDoodard(string name)
        {
            if (variationCount == null)
            {
                throw new Exception("variationCount не инициализирован до создания экземпляра Doodard");
            }
        }*/
        private List<Doodard> doodards = new List<Doodard>();
        // Количество вариантов каждой декорации.
        static Dictionary<string, int> variationCount = null;
        private LocationType type = null;
    }
}
