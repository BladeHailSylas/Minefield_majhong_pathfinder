using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
namespace Program {
    public class MainClass {
        public static void Printer(List<Tile[]> list) {
            for(int i = 0; i < list.Count; i++) {
                Console.Write($"{i}: ");
                for(int j = 0; j < list[i].Length; j++) {
                    Console.Write($"{list[i][j].No}, {list[i][j].Type} | ");
                }
                Console.WriteLine();
            }
        }
        public static void Main() {
            List<Tile[]> tiles = [];
            for(uint i = 1; i < 10; i++) {
                List<Tile> tiler = [];
                for(uint j = 0; j < 4; j++) {
                    tiler.Add(new Tile(i, j));
                }
                tiles.Add([.. tiler]);
                Console.WriteLine();
            }
            Printer(tiles);
            try {
                List<Tile[]> mentsuList = MajhongLogic.FindMentsu([]);
                Printer(mentsuList);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                if(ex.TargetSite.Name == "FindMehtsu") {
                    Console.WriteLine("No Available Mentsu, no further steps.");
                    Environment.Exit(1);
                }
            }
        }
    }
    public class Tile {
        private uint no;
        public uint No {
            get { return no; }
        }
        private uint type;
        public uint Type {
            get { return type; }
        }
        public Tile(uint no, uint type) {
            if(type > 3 || no > 9) {
                throw new ArgumentException("Argument out of range");
            }
            else {
                this.no = no;
                this.type = type;
            }
        }
    }
    public class MajhongCannotWinException : Exception {
        public MajhongCannotWinException() {}
        public MajhongCannotWinException(string message) : base(message){}
        public MajhongCannotWinException(string message, Exception innerException) : base(message,innerException) {}
    }
    public class MajhongLogic {
        public static List<Tile[]> FindMentsu(Tile[] tiles) {
            List<Tile[]> res = [];
            for(int i = 0; i < tiles.Length - 2; i++) {
                if((tiles[i].Type + tiles[i+1].Type + tiles[i+2].Type) / 3.0f != tiles[i+1].Type) {
                    //Nothing Happens
                }
                else if((tiles[i].No + tiles[i].No + tiles[i].No) / 3.0f == tiles[i+1].No){
                    res.Add([tiles[i], tiles[i+1], tiles[i+2]]);
                }
            }
            if(res.Count == 0) throw new MajhongCannotWinException("No possible/available mentsu has found. Did you missed something?");
            else return res;
        }
        public static List<Tile> WaitingMentsu(Tile[] tiles) {
            List<Tile> res = [];

            if(res.Count == 0) throw new MajhongCannotWinException("You can't wait with this hand. Did you missed something?");
            return res;
        }
    }
}