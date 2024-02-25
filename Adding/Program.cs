// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//FunctionOfDataOperations projesinde context nesnemizi tanımladık ve referansını buraya atadık
//bu context nesnesini veri ekleme,güncelleme,silme operasynlarında kullanacağız.
ETicaretDbContext eTicaretDbContext = new();

#region Veri nasıl Eklenir ? 

////önce veri oluşturulur daha sonra ekleme fonksiyonu çağırılır
//Urun urun1 = new()
//{
//    Name = "Set ile ekleme",
//    Price = 35
//};

////bu fonksiyon ile object olarak yani tip güvenliksiz şekilde, biz ürünü context üzerinden ekleme işlemi yapacağımızı belirtiyoruz
//await eTicaretDbContext.AddAsync(urun1);
////ekleme işleminde tip güvenliği ile çalışmak istersek
//await eTicaretDbContext.Set<Urun>().AddAsync(urun1);

////daha sonra SaveChanges fonksiyonu ile CRUD operasyonları veritabanında işleme alınıyor.
//await eTicaretDbContext.SaveChangesAsync();

////eklenen ürünün id bilgisine bu şekilde kolayca ulaşılabilir.
//Console.WriteLine(urun1.Id);

#endregion


#region Çoklu veriyi eklemek

//Urun urun1 = new()
//{
//    Name = "B",
//    Price = 15
//};
//Urun urun2 = new()
//{
//    Name = "C",
//    Price = 23
//};
//Urun urun3 = new()
//{
//    Name = "D",
//    Price = 32
//};

////çoklu ürün eklerken addrange fonksiyonunu kullanıyoruz
//await eTicaretDbContext.AddRangeAsync(urun1, urun2, urun3);


////birden çok ürün aynı anda eklense bile en son yalnızca bir kez SaveChanges dememiz gerekir çünkü bu fonksiyon her çalıştığında yeni bir Transaction oluşur bu da veritabanına maliyet demektir.
//await eTicaretDbContext.SaveChangesAsync();

////eklenen ürünün id bilgisine bu şekilde kolayca ulaşılabilir.
//Console.WriteLine(urun1.Id +" "+urun2.Id+" "+urun3.Id);


#endregion


