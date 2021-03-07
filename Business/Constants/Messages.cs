using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi en az 2 karakter olmalıdır.";
        public static string ProductListed = "Ürünler listelendi.";
        public static string MaintenanceTime = "Bakımda.";
        public static string Uptated = "Güncellendi.";
        public static string NotUptated = "Güncellenemedi.";
        public static string NotAdded = "Eklenemedi.";
        public static string NotDeleted = "Silinemedi.";
        public static string CategoryLimitExceded = "Kategori sayısı aşıldığıiçin sisteme eklenemiyor.";
        public static string CheckIfProductCountOfCategoryCorrect = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string AuthorizationDenied = "Erişim Reddedildi";
        public static string UserRegistered = "Kullanıcı Kayıt Oldu.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Parola Hatalı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mecvut.";
        public static string AccessTokenCreated = "Acces Token oluşturuldu.";
    }
}
