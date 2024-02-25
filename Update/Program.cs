
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

ETicaretDbContext context = new();

#region Veri nasıl güncellenir ? 

////Bir verinini güncellenebilmesi için önce o veri elde edilmelidir. Bu yüzden context nesnesinden veri uygun bir LINQ sorgusu ile çekilir.
////Gelecek veriyi karşılayacak bir nesnemiz olmalı
//Urun urun = await context.Set<Urun>().FirstOrDefaultAsync(u => u.Id==3);
//urun.Name = "Güncellenen ürün";
//urun.Price = 5;

////gelen veri değerlerini kendimiz değiştirdik ve veritabanına tekrar SaveChanges ile göndermiş olduk.
////SaveChanges fonksiyonu bunun bir güncelleme olduğunu urun nesnesine atanırken kullanılan FirstorDefault fonksiyonundan anladı
//await context.SaveChangesAsync();
//Console.WriteLine( urun.Id);
#endregion

#region Takip edilemeyen nesneler nasıl güncelleniR? 
////context üzerinden gelmeyen bir veri oluştururuz bu sayede veri changetracker'a yakalanmamış olur

//Urun urun = new Urun() { Id = 2,Name="Takipsiz" , Price=5};
////Update fonksiyonunu kullanabilmek için ilgili nesnede Id değeri KESİNLİKLE bulunmalıdır.
//context.Set<Urun>().Update(urun);

//await context.SaveChangesAsync();
#endregion

#region EntityState kullanımı

//Urun urun1 = new Urun() { Name="State kullanıyoruz",Price=444};
//Console.WriteLine(context.Entry(urun1).State); //DETACHED

//await context.Set<Urun>().AddAsync(urun1);
//Console.WriteLine(context.Entry(urun1).State); //ADDED
//await context.SaveChangesAsync();


//Urun guncellenecekUrun = await context.Set<Urun>().FirstOrDefaultAsync(u=> u.Price==444);
//guncellenecekUrun.Name = "State güncelleme";
//guncellenecekUrun.Price = 333;
//Console.WriteLine(context.Entry(guncellenecekUrun).State); //MODIFIED
//await context.SaveChangesAsync();

//context.Remove<Urun>(guncellenecekUrun);
//Console.WriteLine(context.Entry(guncellenecekUrun).State); //DELETED

//await context.SaveChangesAsync();

#endregion

#region Birden fazla veride güncelleme işlemi
////sub bir select sorgusu oluşturmak.
////bu liste ile gelen veriler belli bir şarta uygun olacak şekilde seçilebilirdi, bu durumu ileride göreceğiz.
//List<Urun> urunler = await context.Set<Urun>().ToListAsync();
////context üzerinden geldiği için bu nesnelerin hepsi changetracker ile takip edilmekte ve yapılan her değişiklik update sorgusu olarak algılanır
//foreach (var urun in urunler)
//{
//    urun.Name =urun.Price.ToString();
//    Console.WriteLine(urun.Name);
//}
////savechanges metodu döngü içine verilmemeli
//await context.SaveChangesAsync();
#endregion
