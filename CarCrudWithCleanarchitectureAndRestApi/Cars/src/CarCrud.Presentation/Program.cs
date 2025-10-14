using CarCrud.Presentation.Configurations; // DB va DI sozlamalari uchun yozilgan extension methodlar joylashgan

namespace CarCrud.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ASP.NET Core ilovasini ishga tushirish uchun builder obyektini yaratadi
            var builder = WebApplication.CreateBuilder(args);

            // Controllerlani tizimga qo‘shadi (API endpointla shu orqali ishlaydi)
            builder.Services.AddControllers();

            // Swagger uchun endpoint ma’lumotlarini olishga yordam beradi
            builder.Services.AddEndpointsApiExplorer();

            // Swagger’ni tizimga qo‘shadi 
            builder.Services.AddSwaggerGen();

            // Ma’lumotlar bazasini sozlash (EF Core va connection string bilan ishlaydi)
            builder.ConfigureDB();

            // Dependency Injection sozlamalari (service va repositorylarni ro‘yxatdan o‘tkazish)
            builder.ConfigureDI();

            // Barcha servislar tayyor bo‘lgach, projni quradi
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();      // Swagger JSON endpointini yoqadi
                app.UseSwaggerUI();    // Swagger interfeysini ishga tushiradi (vizual panel)
            }

            // HTTP so‘rovlarni avtomatik ravishda HTTPS ga yo‘naltiradi (xavfsizlik uchun)
            app.UseHttpsRedirection();

            // Avtorizatsiya (token yoki rol bilan kirish huquqini tekshiradi)
            app.UseAuthorization();

            // Controllerlardagi route’larni (API yo‘llarni) faollashtiradi
            app.MapControllers();

            // Dastur ishga tushadi va so‘rovlarni kutishni boshlaydi
            app.Run();
        }
    }
}
