using System;
using System.Collections.Generic;
using System.Text;

namespace Dlphn.Constants
{
    public class ConstString : Delphin.Abstraction.Constants.ConstantText
    {
        public class KeyMoq 
        {
            public const string strPhone = "+79261234567";
            public const string strPassoword = "test123";
        }

        public class KeyNavigation
        {
            public const string keyHistoryDetail = nameof(keyHistoryDetail);
        }

        public class KeyImage
        {
            public const string HistoryDataImage=nameof(HistoryDataImage);
            public const string Accounts = nameof(Accounts);
            public const string Contacts = nameof(Contacts);
            public const string Meters = nameof(Meters);
            public const string PersonalAccount = nameof(PersonalAccount);
            public const string Privileges = nameof(Privileges);
            public const string Rates = nameof(Rates);
            public const string Statistic = nameof(Statistic);            
            public const string House=nameof(House);
            public const string Meter = nameof(Meter);
            public const string VerifiedNo = nameof(VerifiedNo);
            public const string VerifiedYes = nameof(VerifiedYes);
            public const string ArrowRight = nameof(ArrowRight);
            public const string ArrowDown = nameof(ArrowDown);
        }
        public class KeyMetter
        {
            public const string strWaterCold = "Холодное водоснабжение";
            public const string strWaterColdShort = "Холодная вода";
            public const string strWaterHot = "Горячее водоснабжение";
            public const string strWaterHotShort = "Горячая вода";
            public const string strElectricity = "Электричество";
            public const string strElectroT1 = "";
            public const string strElectroT2 = "";
            public const string strMeter = "Счетчик № ";

        }

        public class KeyUnitOfMeasurements
        {
            public const string m3 = "м3";
            public const string m2 = "м2";
            public const string kVch = "кВт/ч";
        }

        public class KeySecureStorage
        {
            public const string str_set_data = nameof(str_set_data);
            public const string str_get_data = nameof(str_get_data);

            public const string str_token_access = nameof(str_token_access);
            public const string str_token_refresh = nameof(str_token_refresh);

            public const string str_phone_number = nameof(str_phone_number);

            public const string str_user_id = nameof(str_user_id);

            public const string str_account_id = nameof(str_account_id);
        }
                
    }
    public class AuthByPhoneNumber
    {
        public const string header = "Авторизуйтесь по номеру телефона";
        public const string btnSend = "Отправить";
        public const string lblAuthByloginAndPhone = "Войти по логину и паролю";
        public const string lblPhone = "Телефон";
        public const string entrPlaceholder = "+7";
    }
    public class CheckPasswordByPhone
    {
        public const string header = "Код отправлен в виде СМС и будет активен в течении 10 минут";
        public const string lblEntryHeader = "Код из СМС";
    }

    public class Login
    {
        public const string header = "Введите номер телефона";
        public const string entrPlaceholderInputLogin = "Введите логин";
        public const string entrPlaceholderPassword = "*********";
        public const string lblEntryHeaderInputLogin = "Телефон";
        public const string lblEntryHeaderPassword = "Пароль";
        public const string lblForgotPassword = "Забыли пароль";
        public const string lblInputByPhone = "Войти по телефону";
        public const string btnInput = "Войти";
    }

    public class History
    {
        public const string titleBtnAllOperation = "Все операции";
        public const string titleBtnNachislenia = "Начисления";
        public const string titleBtnOplata = "Оплаты";

        public const string cellHeader = "История счетов и платежей";
    }

    public class Yet
    {
        public const string str_licevoi_schet = "Лицевой счет";
        public const string str_schetchiki = "Счетчики";
        public const string str_tarifi = "Тарифы";
        public const string str_lgoti = "Льготы";
        public const string str_statistic = "Статистика";
        public const string str_account = "Аккаунт";
        public const string str_contacts = "Контакты";
    }

    public class PersonalAccount
    {
        public const string str_personal_account = "Лицевой счет";
        public const string str_contract = "Договор";
        public const string str_total_area = "Общая площадь";
        public const string str_living_area = "Жилая площадь";
        public const string str_flat = "Квартира";
        public const string str_registered_residents = "Зарегистрированные жильцы";
        public const string str_services = "Услуги";
    }

    public class Meters
    {
        public const string str_meters = "Счетчики";
        public const string str_installed = "Установлено";
        public const string str_finished = "Окончание МПИ";
        public const string str_meters_history = "Архив показаний";
    }

    public class MeterHistory
    {
        public const string str_date = "Дата";
        public const string str_value = "Показания";
    }

    public class Raters
    {
        public const string str_rates = "Тарифы";
        public const string str_archive = "Архив";
    }
    public class Account
    {
        public const string str_account = "Аккаунт";
        public const string str_phone = "Телефон";
        public const string str_email = "E-mail";
        public const string str_pasport = "Серия и номер паспорта";
        public const string str_snils = "СНИЛС";
        public const string str_exit = "Выйти";
        public const string str_change_pasword = "Сменить пароль";
        public const string str_old_pasword = "Старый пароль";
        public const string str_new_pasword = "Новый пароль";
        public const string str_repeat_pasword = "Отправить пароль";
        public const string str_send = "Отправить";
    }






    public class TabBarNames
    {
        public const string main = "Главная";
        public const string history = "Операции";
        public const string news = "Новости";
        public const string yet = "Еще";
    }

    public class Staff
    {
        public const string loadData = "Загрузка данных";
    }


    public class CellPersonalAccountShort
    {
        public const string title = "Лицевой счет";
        public const string ls = "ЛС";
        public const string balans = "Баланс";
        public const string btnSendData = "Передать показания";
        public const string btnBuy = "Оплатить";
    }

    public class CellMetterShortHeader
    {
        public const string title = "Последняя передача показаний";
    }

    public class CellNewsGoTo
    {
        public const string btnText = "Все новости";
    }

    public class CellHistoryHeader
    {
        public const string lblHeader = "История счетов и платежей";
    }

    public class MeterSendData
    {
        public const string btnSendData = "Отправить показания";
        public const string lblMetersHistory = "История передачи показаний";
        public const string lblTitle = "Отправить показания";
    }

    public class ControlMeterData
    {
        public const string lblFooter = "Предыдущие показания: ";
    }
}
