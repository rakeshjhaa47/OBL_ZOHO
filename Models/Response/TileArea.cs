using System;

namespace OBL_Zoho.Models.Response
{
    public class TileArea
    {
        public string Size { get; set; }
        public double Area { get; set; }
    }
    public static class TileAreaData
    {
        public static readonly TileArea[] Areas = new TileArea[]
        {
            new TileArea { Size = "1200x1800", Area = 4.32 },
            new TileArea { Size = "300x600", Area = 1.08 },
            new TileArea { Size = "600x600", Area = 1.44 },
            new TileArea { Size = "200x300", Area = 0.9 },
            new TileArea { Size = "300x300", Area = 0.81 },
            new TileArea { Size = "300x450", Area = 0.81 },
            new TileArea { Size = "1000x1000", Area = 2.00 },
            new TileArea { Size = "600x1200", Area = 1.44 },
            new TileArea { Size = "800x2400", Area = 1.92 },
            new TileArea { Size = "800x800", Area = 1.92 },
            new TileArea { Size = "800x1600", Area = 2.56 },
            new TileArea { Size = "250x375", Area = 0.75 },
            new TileArea { Size = "395x395", Area = 0.94 },
            new TileArea { Size = "200x1200", Area = 1.44 },
            new TileArea { Size = "400x400", Area = 0.8 },
            new TileArea { Size = "145x600", Area = 0.7 },
            new TileArea { Size = "195x1200", Area = 0.94 },
            new TileArea { Size = "300x1200", Area = 1.44 },
        };
    }
}
