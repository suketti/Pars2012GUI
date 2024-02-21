namespace Pars2012GUI
{
    public class Versenyzo
    {
        //private String név;
        float[] dobasok = new float[3];

        public Versenyzo(String CSVsor)
        {
            string[] mezok = CSVsor.Split(';');
            //this.név = mezok[0];
            Név = mezok[0];
            Csoport = mezok[1][0]; //A szó első karaktere.
            NemzetÉsKód = mezok[2];

            for (int i = 0; i < 3; i++)
            {
                if (mezok[3 + i][0] == 'X')
                {
                    dobasok[i] = -1;
                }
                else if (mezok[3 + i][0] == '-')
                {
                    dobasok[i] = -2;
                }
                else
                {
                    dobasok[i] = float.Parse(mezok[3 + i]);
                }
            }
        }
        public String Név { get; set; }
        public char Csoport { get; set; }
        public String NemzetÉsKód { get; set; }
        public float D1 { get => this.dobasok[0]; }
        public float D2 { get => this.dobasok[1]; }
        public float D3 { get => this.dobasok[2]; }
        //7. Készítsen a Versenyző osztályban kódtagot (függvényt, jellemzőt stb.) az eredmény meghatározására Eredmény azonosítóval! A kódtag a versenyző legnagyobb dobásának értékét adja vissza!(Ha nem volt érvényes dobása a versenyzőnek, akkor ez - 1.0 lesz.)
        public float Eredmény()
        {
            return Math.Max(Math.Max(this.D1, this.D2), this.D3);
        }

        public float Eredmény2()
        {
            return dobasok.Max();
        }

        public float EredmenyProp => dobasok.Max();


        //8. Készítsen két kódtagot a Versenyző osztályban a nemzet és a nemzet hárombetűs kódjának (rövidítésének) meghatározására Nemzet és Kód azonosítókkal! Ügyeljen rá, hogy a nemzet neve több szóból is állhat! A Kód a nemzet hárombetűs kódjával zárójelek nélkül térjen vissza!

        public String Nemzet()
        {
            int holVan = this.NemzetÉsKód.IndexOf('(');
            return this.NemzetÉsKód.Substring(0, holVan - 1);
        }

        public String Nemzet2 => this.NemzetÉsKód.Substring(0, this.NemzetÉsKód.IndexOf('(') - 1);

        public String Kód => this.NemzetÉsKód.Substring(this.NemzetÉsKód.IndexOf('(') + 1, 3);

        public String Sorozat => $"{D1};{D2};{D3}";

        public override string ToString()
        {
            return $"{Név};{Csoport};{NemzetÉsKód};{D1};{D2};{D3}";
        }
    }
}
