
using lab6.Models;
using lab6.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UchetDbContext db)
        {
            db.Database.EnsureCreated();

            int brandsNumber = 10;
            int ownersNumber = 10;
            int carsNumber = 5;


            InitializeOwners(db, ownersNumber);
            InitializeBrands(db, brandsNumber);
            InitializeCars(db, carsNumber, brandsNumber, ownersNumber);

        }

        private static void InitializeCars(UchetDbContext db, int carsNumber, int brandsNumber, int ownersNumber)
        {
            db.Database.EnsureCreated();

            //Проверка, занесены ли Cars
            if (db.Cars.Any())
            {
                return;   //База данных инициализирована
            }

            InitialStartPageCars(db);

            int brandID;
            int ownerID;
            string carRegistrationNumber;
            string carPhoto;
            string carNumberOfBody;
            string carNumberOfMotor;
            string carNumberOfPassport;
            DateTime carReleaseDate;
            DateTime carRegistrationDate;
            DateTime carLastCheckupDate;
            string carColor;
            string carDescription;


            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int CarID = 13; CarID <= carsNumber; CarID++)
            {
                carRegistrationNumber = MyRandom.RandomString(9);
                carNumberOfBody = MyRandom.RandomString(15);
                carNumberOfMotor = MyRandom.RandomString(15);
                carNumberOfPassport = MyRandom.RandomString(9);
                carColor = MyRandom.RandomString(7);
                carDescription = MyRandom.RandomString(10);

                carReleaseDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carRegistrationDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carLastCheckupDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));

                brandID = randObj.Next(1, brandsNumber - 1);
                ownerID = randObj.Next(1, ownersNumber - 1);
                carPhoto = "";


                db.Cars.Add(new Car
                {
                    BrandID = brandID,
                    OwnerID = ownerID,
                    CarRegistrationNumber = carRegistrationNumber,
                    CarNumberOfPassport = carNumberOfPassport,
                    CarReleaseDate = carReleaseDate,
                    CarColor = carColor
                });

            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
        }

        private static void InitializeBrands(UchetDbContext db, int brandsNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Brands
            if (db.Brands.Any())
            {
                return;   // База данных инициализирована
            }

            InitialStartPageBrands(db);

            string brandName;
            string brandCompany;
            string brandCountry;
            DateTime brandStartDate;
            DateTime brandEndingDate;
            string brandCharacteristic;
            string brandCategory;
            string brandDescription;


            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int BrandID = 11; BrandID <= brandsNumber; BrandID++)
            {
                brandName = MyRandom.RandomString(7);
                brandCompany = MyRandom.RandomString(10);
                brandCountry = MyRandom.RandomString(10);
                brandStartDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandEndingDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandCharacteristic = MyRandom.RandomString(15);
                brandCategory = MyRandom.RandomString(7);
                brandDescription = MyRandom.RandomString(10);


                db.Brands.Add(new Brand
                {
                    BrandName = brandName,
                    BrandCompany = brandCompany,
                    BrandCountry = brandCountry
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
        }

        private static void InitializeOwners(UchetDbContext db, int ownersNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Owners
            if (db.Owners.Any())
            {
                return;   // База данных инициализирована
            }

            InitialStartPageOwner(db);

            string ownerName;
            DateTime ownerBirthDate;
            string ownerAddress;
            string ownerPassport;
            int ownerNumberOfDriverLicense;
            DateTime ownerLicenseDeliveryDate;
            DateTime ownerLicenseValidityDate;
            string ownerCategory;
            string ownerMoreInformation;

            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int OwnerID = 11; OwnerID <= ownersNumber; OwnerID++)
            {
                ownerName = MyRandom.RandomString(20);
                ownerAddress = MyRandom.RandomString(20);
                ownerPassport = MyRandom.RandomString(10);
                ownerBirthDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseDeliveryDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseValidityDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerCategory = MyRandom.RandomString(15);
                ownerNumberOfDriverLicense = randObj.Next(1, 3000);
                ownerMoreInformation = MyRandom.RandomString(10);


                db.Owners.Add(new Owner
                {
                    OwnerName = ownerName,
                    OwnerBirthDate = ownerBirthDate,
                    OwnerAddress = ownerAddress
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
        }





        private static void InitialStartPageCars(UchetDbContext db)
        {
            db.Cars.Add(new Car
            {
                BrandID = 2,
                OwnerID = 1,
                CarRegistrationNumber = "3194 KK-4",
                CarNumberOfPassport = "EGFV4151V",
                CarReleaseDate = new DateTime(2005, 12, 08),
                CarColor = "Голубой"
            });

            db.Cars.Add(new Car
            {
                BrandID = 5,
                OwnerID = 4,
                CarRegistrationNumber = "3826 AT-2",
                CarNumberOfPassport = "RG22X9GRE",
                CarReleaseDate = new DateTime(2008, 11, 08),
                CarColor = "Синий"
            });

            db.Cars.Add(new Car
            {
                BrandID = 8,
                OwnerID = 1,
                CarRegistrationNumber = "8864 EH-3",
                CarNumberOfPassport = "ERGV415GV",
                CarReleaseDate = new DateTime(2009, 12, 18),
                CarColor = "Серый"
            });

            db.Cars.Add(new Car
            {
                BrandID = 9,
                OwnerID = 5,
                CarRegistrationNumber = "3181 EE-6",
                CarNumberOfPassport = "EDBED4DED",
                CarReleaseDate = new DateTime(2015, 08, 28),
                CarColor = "Черный"
            });

            db.Cars.Add(new Car
            {
                BrandID = 1,
                OwnerID = 6,
                CarRegistrationNumber = "4181 EP-6",
                CarNumberOfPassport = "5520ERG9Z",
                CarReleaseDate = new DateTime(2009, 02, 06),
                CarColor = "Черный"
            });

            db.Cars.Add(new Car
            {
                BrandID = 3,
                OwnerID = 9,
                CarRegistrationNumber = "4000 IX-5",
                CarNumberOfPassport = "EGVE5241V",
                CarReleaseDate = new DateTime(2008, 07, 20),
                CarColor = "Белый"
            });

            db.Cars.Add(new Car
            {
                BrandID = 6,
                OwnerID = 10,
                CarRegistrationNumber = "4442 BX-3",
                CarNumberOfPassport = "ERGVRE5G9",
                CarReleaseDate = new DateTime(2011, 12, 12),
                CarColor = "Синий"
            });

            db.Cars.Add(new Car
            {
                BrandID = 4,
                OwnerID = 7,
                CarRegistrationNumber = "1990 KO-7",
                CarNumberOfPassport = "ERGVSRE96",
                CarReleaseDate = new DateTime(2016, 05, 01),
                CarColor = "Черный"
            });

            db.Cars.Add(new Car
            {
                BrandID = 7,
                OwnerID = 3,
                CarRegistrationNumber = "0813 BT-3",
                CarNumberOfPassport = "REGV85518",
                CarReleaseDate = new DateTime(2010, 10, 10),
                CarColor = "Серый"
            });

            db.Cars.Add(new Car
            {
                BrandID = 4,
                OwnerID = 6,
                CarRegistrationNumber = "0996 AX-2",
                CarNumberOfPassport = "RFV541R24",
                CarReleaseDate = new DateTime(2005, 09, 21),
                CarColor = "Красный"
            });

            db.SaveChanges();
        }

        private static void InitialStartPageBrands(UchetDbContext db)
        {
            db.Brands.Add(new Brand
            {
                BrandName = "Audi SQ7",
                BrandCompany = "Audi",
                BrandCountry = "Germany"   });

            db.Brands.Add(new Brand
            {
                BrandName = "BMW M5 (E60)",
                BrandCompany = "BMW",
                BrandCountry = "Germany"  });

            db.Brands.Add(new Brand
            {
                BrandName = "Mercedes-Benz S500",
                BrandCompany = "Mercedes-Benz",
                BrandCountry = "Germany" });

            db.Brands.Add(new Brand
            {
                BrandName = "Ford EcoSport 1.6",
                BrandCompany = "Ford",
                BrandCountry = "USA"  });

            db.Brands.Add(new Brand
            {
                BrandName = "Toyota Corolla 1.33",
                BrandCompany = "Toyota",
                BrandCountry = "Japan"});

            db.Brands.Add(new Brand
            {
                BrandName = "Hyundai Avante 1.6",
                BrandCompany = "Hyundai",
                BrandCountry = "South Korea" });

            db.Brands.Add(new Brand
            {
                BrandName = "Renault Wind 1.2",
                BrandCompany = "Renault",
                BrandCountry = "Slovenia" });

            db.Brands.Add(new Brand
            {
                BrandName = "Mazda CX-9 3.7 4WD",
                BrandCompany = "Mazda",
                BrandCountry = "Japan"});

            db.Brands.Add(new Brand
            {
                BrandName = "Honda Crosstour 2.4",
                BrandCompany = "Honda",
                BrandCountry = "Japan"  });

            db.Brands.Add(new Brand
            {
                BrandName = "Subaru Impreza WRX 2.0",
                BrandCompany = "Subaru",
                BrandCountry = "Japan" });


            db.SaveChanges();
        }

        private static void InitialStartPageOwner(UchetDbContext db)
        {
            db.Owners.Add(new Owner
            {
                OwnerName = "Исаева Екатерина Евгеньевна",
                OwnerBirthDate = new DateTime(1998, 02, 21),
                OwnerAddress = "Беларусь, г. Гомель, ул. Ленина, д. 2"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Гордеев Евгений Михайлович",
                OwnerBirthDate = new DateTime(1975, 12, 25),
                OwnerAddress = "Беларусь, г. Гомель, ул. Свиридова, д. 30, кв. 52"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Ситников Александр Дмитриевич",
                OwnerBirthDate = new DateTime(1988, 01, 08),
                OwnerAddress = "Беларусь, г. Гомель, ул. Привокзальная, д. 45, кв. 12"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Шестакова Анастасия Андреевна",
                OwnerBirthDate = new DateTime(1958, 03, 19),
                OwnerAddress = "Беларусь, г. Гомель, ул. Ленина, д. 8, кв. 96"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Симонов Андрей Вячеславович",
                OwnerBirthDate = new DateTime(1966, 07, 07),
                OwnerAddress = "Беларусь, г. Гомель, ул. Октябрьская, д. 25, кв. 48"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Фёдорова Лидия Викторовна",
                OwnerBirthDate = new DateTime(1985, 11, 06),
                OwnerAddress = "Беларусь, г. Гомель, ул. Воровского, д. 36, кв. 4"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Гришина Надежда Анатольевна",
                OwnerBirthDate = new DateTime(1981, 05, 01),
                OwnerAddress = "Беларусь, г. Гомель, ул. Гомельская, д. 19"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Пономарёв Роман Святославович",
                OwnerBirthDate = new DateTime(1992, 07, 16),
                OwnerAddress = "Беларусь, г. Гомель, ул. Карповича, д. 7, кв. 64"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Крылов Алексей Михаилович",
                OwnerBirthDate = new DateTime(1979, 09, 10),
                OwnerAddress = "Беларусь, г. Гомель, ул. Белорусская, д. 5"
            });

            db.Owners.Add(new Owner
            {
                OwnerName = "Устинов Валерий Глебович",
                OwnerBirthDate = new DateTime(1996, 05, 12),
                OwnerAddress = "Беларусь, г. Гомель, ул. Мазурова, д. 45, кв. 3"
                     });

            db.SaveChanges();
        }


    }

}
