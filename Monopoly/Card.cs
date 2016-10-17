using System;
namespace Monopoly
{
    [Serializable]
    public class Card
    {
        public string Category { set; get; }        //Chest or Chance
        public string Instruction { set; get; }     //Move,Pay,Rcv,Collect,Payall
        public string Description { set; get; }     //descript the function of the card

        public Card(string category,string instruction,string description)
        {
            Category = category;
            Instruction = instruction;
            Description = description;
        }
        public override string ToString()
        {
            return ($"{Category} Card: {Description}");
        }

        public virtual void ExecuteInstruction(Player player)
        {
            Console.WriteLine(this.ToString());
        }
    }
}
