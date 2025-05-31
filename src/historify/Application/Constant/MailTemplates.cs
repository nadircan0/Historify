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
    public const string SUBJECT = "Şifre Sıfırlama";
    public static string GetBody(string code, string name)
        => $@"
            <div style='font-family: Arial, sans-serif; font-size: 16px; color: #222; max-width: 600px; margin: 0 auto; background-color: #f7f7f7; padding: 20px; border-radius: 8px;'>
                <div style='background-color: white; padding: 30px; border-radius: 6px; box-shadow: 0px 2px 10px rgba(0,0,0,0.08);'>
                    <div style='text-align: center; border-bottom: 1px solid #eee; padding-bottom: 20px; margin-bottom: 20px;'>
                        <h2 style='color: #2a7ae2; margin-bottom: 10px; font-weight: 600;'>Şifre Sıfırlama</h2>
                    </div>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Sayın {name},</p>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Şifre sıfırlama talebiniz alınmıştır. Yeni şifreniz aşağıdaki gibidir:</p>
                    <div style='background-color: #f0f4ff; padding: 15px; border-radius: 5px; text-align: center; margin: 25px 0;'>
                        <span style='font-size: 24px; font-weight: bold; letter-spacing: 2px; color: #2a7ae2;'>{code}</span>
                    </div>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Güvenliğiniz için lütfen giriş yaptıktan sonra şifrenizi değiştiriniz.</p>
                    <div style='margin-top: 30px; padding-top: 20px; border-top: 1px solid #eee; font-size: 13px; color: #777; text-align: center;'>
                        <p>Bu e-posta otomatik olarak gönderilmiştir, lütfen yanıtlamayınız.</p>
                    </div>
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