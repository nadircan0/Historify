namespace Application.Constants;

public static class MailTemplates
{
    public static class Settings
    {
        public const bool USE_HTML = true;
        public const string FONT_FAMILY = "'Segoe UI', Roboto, Arial, sans-serif";
        public const string FONT_SIZE = "15px";
        public const string PRIMARY_COLOR = "#4A6FFF";
        public const string SECONDARY_COLOR = "#F5F7FF";
        public const string TEXT_COLOR = "#333333";
    }

    public static class PasswordReset
    {
        public const string SUBJECT = "🔐 Şifrenizi Sıfırlamak İçin Özel Kodunuz";
        public static string GetBody(string code) => $@"
            <div style='font-family: {Settings.FONT_FAMILY}; font-size: {Settings.FONT_SIZE}; color: {Settings.TEXT_COLOR}; max-width: 600px; margin: 0 auto; padding: 20px; border-radius: 8px; border: 1px solid #e0e0e0; background-color: #ffffff;'>
                <div style='text-align: center; padding: 15px 0; margin-bottom: 20px; background-color: {Settings.SECONDARY_COLOR}; border-radius: 6px;'>
                    <h2 style='color: {Settings.PRIMARY_COLOR}; margin: 0;'>Merhaba Değerli Üyemiz!</h2>
                </div>
                <p style='margin-bottom: 15px;'>Şifrenizi sıfırlamak için talebinizi aldık. İşte size özel kodunuz:</p>
                <div style='background-color: {Settings.SECONDARY_COLOR}; padding: 15px; border-radius: 6px; text-align: center; margin: 20px 0;'>
                    <span style='font-size: 24px; font-weight: bold; letter-spacing: 2px; color: {Settings.PRIMARY_COLOR};'>{code}</span>
                </div>
                <p>Bu kod <strong>15 dakika</strong> boyunca geçerlidir.</p>
                <p style='margin-top: 25px;'>Eğer şifre sıfırlama talebinde bulunmadıysanız, lütfen bu e-postayı dikkate almayınız.</p>
                <div style='margin-top: 30px; padding-top: 15px; border-top: 1px solid #e0e0e0; text-align: center; font-size: 13px; color: #777777;'>
                    <p>Güvenliğiniz bizim için önemli. Hesabınızla ilgili herhangi bir sorunuz olursa bizimle iletişime geçebilirsiniz.</p>
                    <p>Sevgiler,<br>Shut Ekibi</p>
                </div>
            </div>";
    }


    public static class WelcomeMessage
    {
        public const string SUBJECT = "🎉 Histofy' a Hoş Geldiniz!";
        public static string GetBody(string userName) => $@"
            <div style='font-family: {Settings.FONT_FAMILY}; font-size: {Settings.FONT_SIZE}; color: {Settings.TEXT_COLOR}; max-width: 600px; margin: 0 auto; padding: 20px; border-radius: 8px; border: 1px solid #e0e0e0; background-color: #ffffff;'>
                <div style='text-align: center; padding: 20px 0; margin-bottom: 20px; background-color: {Settings.SECONDARY_COLOR}; border-radius: 6px;'>
                    <h2 style='color: {Settings.PRIMARY_COLOR}; margin: 0;'>Merhaba {userName}!</h2>
                </div>
                <p style='margin-bottom: 15px;'>Histofy ailesine hoş geldiniz! Aramıza katıldığınız için çok mutluyuz.</p>
                <p>Sizin için hazırladığımız özelliklerimizi keşfetmeye başlayabilirsiniz:</p>
                <ul style='margin: 20px 0; padding-left: 20px;'>
                    <li style='margin-bottom: 10px;'>Kişiselleştirilmiş deneyim</li>
                    <li style='margin-bottom: 10px;'>Güvenli ve hızlı işlemler</li>
                    <li style='margin-bottom: 10px;'>7/24 destek</li>
                </ul>
                <p style='margin-top: 25px;'>Herhangi bir sorunuz olursa, yanıtlamaktan mutluluk duyarız.</p>
                <div style='margin-top: 30px; padding-top: 15px; border-top: 1px solid #e0e0e0; text-align: center; font-size: 13px; color: #777777;'>
                    <p>Size harika bir deneyim sunmak için buradayız!</p>
                    <p>Sevgilerimizle,<br>Histofy Ekibi</p>
                </div>
            </div>";
    }

} 