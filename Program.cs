using barlangol;
using System.Collections.Generic;

List<Barlang> lista = new List<Barlang>();

FileStream fs = new FileStream("..\\..\\..\\barlangok.txt",FileMode.Open);
StreamReader sr = new StreamReader(fs);
sr.ReadLine();
while (!sr.EndOfStream)
{
    Barlang b = new Barlang(sr.ReadLine());
    lista.Add(b);
}
sr.Close();
fs.Close();

//4
Console.WriteLine($"\n4. feladat: {lista.Count()}");

//5
int db = 0;
double atlag = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Telepules.Contains("Miskolc"))
    {
        db++;
        atlag += lista[i].Melyseg;
    }
}
atlag = atlag / db;
atlag = Math.Round(atlag,3);
Console.WriteLine($"\n5. feladat: Átlag mélység: {atlag} m");

//6
Console.Write($"\n6. feladat: Kérem a védettségi szintet: ");
string szint = Console.ReadLine();
bool igaze = false;
List<int> szintlista = new List<int>();
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Vedettseg == szint)
    {
        igaze = true;
        szintlista.Add(lista[i].Hossz);
    }
}
if (igaze == false)
{
    Console.WriteLine("Nincs ilyen védetttségi szinttel a barlangok között adat!");
}
else
{
    int max = 0;
    for (int i = 0;i < szintlista.Count; i++)
    {
        if (szintlista[i] > szintlista[max])
        {
            max = i;
        }
    }
    max = szintlista[max];
    int szam = 0;
    for (int i = 0;i < lista.Count ; i++)
    {
        if (lista[i].Hossz == max)
        {
            szam = i;
        }
    }
    Console.WriteLine($"Azon: {lista[szam].Azon}\n" +
        $"Név: {lista[szam].Nev}\n" +
        $"Hossz: {lista[szam].Hossz} m\n" +
        $"Mélység: {lista[szam].Melyseg} m\n" +
        $"Település: {lista[szam].Telepules}");
}

//7
Console.WriteLine("\n7. feladat: Statisztika");
var f7 = lista.GroupBy(v => v.Vedettseg);
foreach (var vedcsop in f7)
{
    Console.WriteLine($"\t{vedcsop.Key}:----> {vedcsop.Count()} db");
}