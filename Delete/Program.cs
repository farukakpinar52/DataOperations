// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
//CRUD operasyonları , transaction oluşturmak , stockprocedure oluşturmak v.s. için her zaman context nesnesine ihtiyacımız var.
ETicaretDbContext context = new ETicaretDbContext();
//TODO: ilişkisel tablolarda veri silme davranışını ileride öğreneceğiz. Şimdi en basit düzeyde bir tablodan nasıl veri silinebilir onu öğrenceğiz.

#region Veri nasıl silinir?
////1.adım : silinecek veri context üzerinden getirilir.
//Urun silinecekData = await context.Set<Urun>().FirstOrDefaultAsync(u=>u.Id==5);

////2.adım : ürün veritabanından Remove komutu ile silinir
//Console.WriteLine("Silinecek verinin adı : {0}", silinecekData.Name);
//context.Set<Urun>().Remove(silinecekData);

////işlemin execute edilmesi için SavecChanges fonksiyonu çağırılır
//await context.SaveChangesAsync();
#endregion

#region Silme işleminde Changetracker'ın rolü
//veri context üzerinden elde edildiği için veriyi takip eder. update ve delete işlemlerinde changetracker vardır.
#endregion

#region Takip edilmeyen veriler nasıl silinir ? 
//veriler bize dışardan getirildiğinde o verinin id bilgisini alıp veritabanına göndererek silme işlemini yapabiliriz
//Urun urun1 = new Urun() { Id=2};
//context.Set<Urun>().Remove(urun1);
//await context.SaveChangesAsync();

#endregion

#region EntityState ile silme işlemi ?
//Urun urun2 = new Urun() { Id=3};
////verinin durumunu silinmiş olarak işaretlediğizde ve savechanges çağırıldığında yapılan transaction işlemi veritabana gidip execute edilir.
//context.Entry<Urun>(urun2).State = EntityState.Deleted;
//await context.SaveChangesAsync();

#endregion

#region ÇOKLU veriyi tek seferde silmek. RemoveRange fonksiyonu

////silinecek veriler önce veritabanından liste halinde çekilir bunun için where şartı ile belirli şartı sağlayan getirilebilir.
//List<Urun> datas = await context.Set<Urun>().Where(u => u.Id > 13 && u.Id < 20).ToListAsync();
//// QUERY kısmı : await context.Set<Urun>().Where(u=>u.Id>13 && u.Id<20)
//// ToListAsync ile biz bu IQuery sorgumuzu IEnumerable haline getiriyoruz. O Yüzden gelen veriyi INumerable 'ı referans alan List<> ile karşılıyoruz
//context.Set<Urun>().RemoveRange(datas);
//foreach (Urun data in datas)
//{
//    Console.WriteLine("Silinen veriler :" + data.Name);
//}
//await context.SaveChangesAsync();
#endregion

