using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoShootConfiguration : IEntityTypeConfiguration<PhotoShoot>
    {
        public void Configure(EntityTypeBuilder<PhotoShoot> builder)
        {
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(p => p.CreatedAt)
                .HasDefaultValue(DateTime.Now);

            builder.HasData(SeedPhotoShoots());
        }

        private IEnumerable<PhotoShoot> SeedPhotoShoots()
        {
            IEnumerable<PhotoShoot> photoShoots = new List<PhotoShoot>()
            {
                new PhotoShoot()
                {
                    Name ="Декор с балони и маргаритки – свежест и радост в едно!",
                    ImageUrl1="https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg",
                    ImageUrl2 ="https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg",
                    Description ="Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n\u2728 Как изглежда декорът?\n\n\ud83c\udf88 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n\ud83c\udf3c Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n\ud83c\udf3f Малки зелени акценти за още повече природна свежест.\n\ud83c\udf1f Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n\ud83d\udca1 За какви събития е подходящ?\n\n\ud83c\udf82 Рождени дни и празненства с пролетна или лятна тематика.\n\ud83d\udc76 Бебешки фотосесии или кръщенета.\n\ud83e\udd42 Романтични събития като годежи или сватбени фотосесии.\n\ud83d\udcf8 Тематични фотосесии на открито или в уютна студийна атмосфера.\n\u2728 Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.",
                    PhotographerId =Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new PhotoShoot()
                {
                    Name ="Декор с балони и облаци – магията на мечтите!",
                    ImageUrl1="https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg",
                    ImageUrl2 ="https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg",
                    Description ="Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n\u2728 Как изглежда декорът?\n\n\ud83c\udf25\ufe0f Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n\ud83c\udf88 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n\u2728 Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n\ud83c\udf1f Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n\ud83d\udca1 За кого е подходящ този декор?\n\n\ud83d\udc76 Бебешки фотосесии и рождени дни.\n\ud83d\udc8d Романтични моменти като предложения за брак или годежи.\n\ud83c\udf89 Детски партита и тематични събития.\n\ud83d\udcf8 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! \u2728\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.",
                    PhotographerId =Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new PhotoShoot()
                {
                    Name ="Едноцветен декор – стил, елегантност и изчистена визия!",
                    ImageUrl1="https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg",
                    ImageUrl2 ="https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg",
                    ImageUrl3 = "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg",
                    Description ="Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n\ud83c\udf82 Рождени дни със стилна концепция.\n\ud83e\udd42 Романтични вечери, предложения за брак или годежи.\n\ud83d\udcf8 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n\ud83c\udf89 Корпоративни събития с изискана атмосфера.\n\u2728 Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. \ud83c\udf88 Направи събитието си незабравимо с простота, която говори сама за себе си!",
                    PhotographerId =Guid.Parse("01A0E6F6-DA36-4634-9533-E6BD4E861C11")
                }
            };

            return photoShoots;
        }
    }
}
