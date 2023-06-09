using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using wiKorki.Data.Static;

namespace wikorki.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //hsClasses
                if (!context.HSClasses.Any())
                {
                    context.HSClasses.AddRange(new List<HSClass>()
                    {
                        new HSClass()
                        {
                            Name = "Klasa 1",
                        },
                        new HSClass()
                        {
                            Name = "Klasa 2",
                        },
                        new HSClass()
                        {
                            Name = "Klasa 3",
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Chapters.Any())
                {
                    context.Chapters.AddRange(new List<Chapter>()
                    {
                        new Chapter()
                        {
                            Name = "Liczby Rzeczywiste",
                            HSClassId = 1,
                        },
                        new Chapter()
                        {
                            Name = "Wyrażenia algebraiczne",
                            HSClassId = 1,
                        },
                        new Chapter()
                        {
                            Name = "Równania i nierówności",
                            HSClassId = 1,
                        },

                        new Chapter()
                        {
                            Name = "Układy równań",
                            HSClassId = 1,
                        },
                        new Chapter()
                         {
                            Name = "Funkcje",
                            HSClassId = 1,
                        },
                        new Chapter()
                        {
                            Name = "Ciągi",
                            HSClassId = 2,
                        },
                        new Chapter()
                        {
                            Name = "Trygonometria",
                            HSClassId = 2,
                        },
                        new Chapter()
                        {
                            Name = "Planimetria",
                            HSClassId = 2,
                        },
                        new Chapter()
                        {
                            Name = "Geometria Analityczna",
                            HSClassId = 2,
                        },
                        new Chapter()
                        {
                            Name = "Stereometria",
                            HSClassId = 3,
                        },
                        new Chapter()
                        {
                            Name = "Kombinatoryka",
                            HSClassId = 3,
                        },
                        new Chapter()
                        {
                            Name = "Rachunek Prawdopodobieństwa",
                            HSClassId = 3,
                        },
                        new Chapter()
                        {
                            Name = "Optymalizacja i rachunek różniczkowy",
                            HSClassId = 3,
                        },

                    });
                    context.SaveChanges();
                }

                if (!context.Exercises.Any())
                {
                    context.Exercises.AddRange(new List<Exercise>()
                    {
                        new Exercise()
                        {
                            ChapterId = 1,
                            Name = "Obliczenia procentowe",
                            Content = "Liczba 78 jest o 50% większa od c. Oblicz c."
                        },

                        new Exercise()
                        {
                            ChapterId = 1,
                            Name = "Obliczenia logarytmiczne",
                            Content = "Ile wynosi suma log₈16 + 1 ?"
                        },
                        new Exercise()
                        {
                            ChapterId = 1,
                            Name = "Podzielność liczb. Dowód",
                            Content = "Udowodnij, że każda liczba całkowita k, która przy dzieleniu przez 7 daje resztę 2, ma tę własność, że reszta z dzielenia liczby 3k² przez 7 jest równa 5."
                        },
                        new Exercise()
                        {
                            ChapterId = 1,
                            Name = "Błąd bezwzględny",
                            Content = "Liczba 15 jest przybliżeniem z niedomiarem liczby x. Błąd bezwzględny tego przybliżenia jest równy 0,24. Ile wynosi liczba x?"
                        } ,
                        new Exercise()
                        {
                            ChapterId = 2,
                            Name = "Wykorzystanie wzorów skróconego mnożenia",
                            Content = "Uprość wyrażenie 16 - (3x + 1)²"
                        },
                        new Exercise()
                        {
                            ChapterId = 2,
                            Name = "Sprowadzanie wyrażeń do wspólnego mianownika",
                            Content = "Uprość wyrażenie ³ˣ⁺¹⁄ₓ₋₂ - ²ˣ⁻¹⁄ₓ₊₃"
                        },
                         new Exercise()
                         {
                            ChapterId = 2,
                            Name = "Prawdziwość nierówności. Dowód",
                            Content = "Wykaż, że dla każdych dwóch różnych liczb rzeczywistych a i b prawdziwa jest nierówność:" +
                            "a(a - 2b) + 2b² > 0"
                         },
                          new Exercise()
                          {
                            ChapterId = 3,
                            Name = "Rozwiązanie nierówności. Zbiór",
                            Content = "Podaj zbiór rozwiązań nierówności:" +
                            "²⁻ˣ⁄₃ - ²ˣ⁻¹⁄₂ < x"
                          },
                          new Exercise()
                          {
                            ChapterId = 3,
                            Name = "Równanie kwadratowe. Rozwiązanie",
                            Content = "Podaj dwie liczby będące rozwiązaniem równania:" +
                            "(2x - 1)(x - 2) = (1 - 2x)(x + 2)"
                          },
                          new Exercise()
                          {
                            ChapterId = 3,
                            Name = "Liczby spełniające nierówność",
                            Content = "Podaj najmniejszą liczbę całkowitą, która spełnia nierówność:" +
                            "ˣ⁄₂ ≤  ²ˣ⁄₃ + ¼"
                          },
                          new Exercise()
                          {
                            ChapterId = 4,
                            Name = "Rozwiązania układu równań",
                            Content = "Podaj rozwiązania układu równań:" + "⎧  2x + 3y = 10\n"
                            + "⎩  4x - 2y = 3"
                          },
                          new Exercise()
                          {
                            ChapterId = 5,
                            Name = "Wartość funkcji wykładniczej",
                            Content = "Jaką wartość przyjmuje funkcja wykładnicza określona wzorem f(x) = 3ˣ dla argumentu 6?"
                          },
                          new Exercise()
                          {
                            ChapterId = 5,
                            Name = "Interpretacja opisu funkcji",
                            Content = "Funkcja f przyporządkowuje każdej liczbie naturalnej większej od 1 jej największy dzielnik będący liczbą pierwszą. Która z pośród poniższych liczb jest największa?" +
                            "f(42), f(44), f(45), f(48) "
                          },
                          new Exercise()
                          {
                            ChapterId = 5,
                            Name = "Zadanie z parametrem m. Monotoniczność",
                            Content = "Podaj wartość parametru m dla którego funkcja liniowa f(x) = (m² - 4)x + 2 jest malejąca."
                          },
                          new Exercise()
                          {
                            ChapterId = 6,
                            Name = "Obliczanie wartości danego wyrazu ciągu",
                            Content = "W dziewięciowyrazowym ciągu geometrycznym o wyrazach dodatnich pierwszy wyraz jest równy 3, a ostatni 12. Oblicz piąty wyraz tego ciągu."
                          },
                          new Exercise()
                          {
                            ChapterId = 6,
                            Name = "Wyznaczanie wzoru ogólnego ciągu arytmetycznego",
                            Content = "Liczby 2, -1, -4 są trzema początkowymi wyrazami ciągu arytmetycznego (aₙ), określonego dla liczby natualnych n ≥ 1. Podaj wzór ogólny tego ciągu."
                          },
                          new Exercise()
                          {
                            ChapterId = 7,
                            Name = "Obliczanie wartości wyrażenie trygonometrycznego",
                            Content = "Kąt α jest ostry i sin α = √(3/2). Oblicz wartość wyrażenie cos² α - 2. "
                          },
                          new Exercise()
                          {
                            ChapterId = 7,
                            Name = "Stosowanie wzorów trygonometrycznych",
                            Content = "Oblicz wartość wyrażenia tg30° - sin 30."
                          },
                          new Exercise()
                          {
                            ChapterId = 8,
                            Name = "Podobieństwo trójkątów. Skala podobieństwa",
                            Content = "Trójkąty ABC i A'B'C' są podobne, a ich pola są odpowiednio, równe 25cm² i 50cm². Oblicz skalę podobieństwa odcinka A'B' do AB."
                          },
                          new Exercise()
                          {
                            ChapterId = 8,
                            Name = "Pole rombu. Kąty",
                            Content = "Dany jest romb o boku długości 4 oraz kącie rozwartym 150°. Oblicz pole tego rombu."
                          },
                          new Exercise()
                          {
                            ChapterId = 9,
                            Name = "Kwadrat na płaszczyźnie kartezjańskiej. Przekątna kwadratu",
                            Content = "Punkty E = (7,1) i F = (9,7) to środki boków, odpowiednio AB i BC kwadratu ABCD. Oblicz długość przekątnej tego kwadratu."
                          },
                          new Exercise()
                          {
                            ChapterId = 9,
                            Name = "Równania prostych równoległych",
                            Content = "Wskaż równanie prostej równoległej do prostej o równaniu 3x - 6y + 7."
                          },
                          new Exercise()
                          {
                            ChapterId = 10,
                            Name = "Stożek. Stosunek promienia do tworzącej",
                            Content = "Tworząca stożka ma długość l, a promień jego podstawy jest równy r. Powierzchnia boczna tego stożka jest 2 razy większa od pola jego podstawy. Podaj stosunek promienia do tworzącej."
                          },
                          new Exercise()
                          {
                            ChapterId = 10,
                            Name = "Liczba krawędzi i ścian w ostrosłupie",
                            Content = "Ostrosłup ma 10 krawędzi. Ile wynosi liczba jego ścian bocznych?"
                          },
                          new Exercise()
                          {
                            ChapterId = 11,
                            Name = "Ile jest możliwości?",
                            Content = "W karcie dań jest 5 zup  i 4 drugie dania. Na ile sposobów można zamówić obiad składający się z jednej zupy i jednego drugiego dania?"
                          },
                          new Exercise()
                          {
                            ChapterId = 11,
                            Name = "Ile jest liczb naturalnych...",
                            Content = "Oblicz, ile jest liczb naturalnych pięciocyfrowych, w zapisie których nie występuje zero, jest dokładnie jedna cyfra 7 i dokładnie jedna cyfra parzysta."
                          },
                          new Exercise()
                          {
                            ChapterId = 11,
                            Name = "Ile jest wszystkich liczb...",
                            Content = "Ile jest wszystkich liczb naturalnych trzycyfrowych podzielnych przez 5?"
                          },
                          new Exercise()
                          {
                            ChapterId = 12,
                            Name = "Prawdopodobieństwo losowego zdarzenia",
                            Content = "Ze zbioru {1,2,3,4,5,6,7,8,9,10,11} wybieramy losowo jedną liczbę. Niech p oznacza prawdopodobieństwo wybrania liczby będącej wielokrotnością liczby 3. Oblicz p."
                          },
                           new Exercise()
                          {
                            ChapterId = 12,
                            Name = "Prawdopodobieństwo rzutu sześcienną kostką",
                            Content = "Rzucamy dwa razy symetryczną sześcienną kostką do gry. Oblicz prawdopodobieństwo otrzymania sumy oczek równej trzy."
                          },
                           new Exercise()
                          {
                            ChapterId = 13,
                            Name = "Optymalizacja pól dwóch kwadratów",
                            Content = "Suma obwodów dwóch kwadratów jest równa 64 cm. Oblicz długości boków kwadratów, dla których suma ich pól jest najmniejsza. Oblicz sumę tych pól P(min)."
                          },
                           new Exercise()
                          {
                            ChapterId = 13,
                            Name = "Optymalna długość odcinka, a oś OY",
                            Content = "Na płaszczyźnie dane są punkty A =(3,5) i B =(9,7). Na osi OY znajdź punkt C, dla którego suma |AC|²+|BC|² jest najmniejsza.​​​​​​​"
                          },





                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {
                //roles section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //users section
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@wikorki.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = "admin@wikorki.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding!23");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var appUser = await userManager.FindByEmailAsync("user@wikorki.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = "user@wikorki.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding!23");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }



    }
}
