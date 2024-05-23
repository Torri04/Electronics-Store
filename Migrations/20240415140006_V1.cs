using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_Core_MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryShortDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "ProductCategoryID", "CategoryName", "CategoryShortDescription" },
                values: new object[,]
                {
                    { 1, "Rerum.", "Ipsa est quasi." },
                    { 2, "Fuga.", "Perferendis ut molestiae tenetur adipisci aliquid quod quas quidem. Possimus eveniet fugit." },
                    { 3, "Et.", "Dolor officia necessitatibus blanditiis eligendi ea asperiores deleniti. Quam iure odio. Corrupti aperiam eos. Et et totam officiis et aperiam." },
                    { 4, "Omnis.", "Ea ipsa quasi at est esse aperiam vel mollitia. Id officiis explicabo est voluptates hic. Est sapiente corporis atque ratione sit eveniet laudantium ab." },
                    { 5, "Quis.", "Aut iste magni earum non repellat tenetur velit ut. Ut ea facilis saepe omnis quia natus aut. Iste molestiae incidunt quaerat quibusdam non minima quaerat." },
                    { 6, "Accusantium.", "Est quae et officia atque molestiae." },
                    { 7, "Est.", "Est tenetur sed similique. Doloribus ut quo aliquam. Omnis ut architecto id aut et. Exercitationem sit minus est quod non labore debitis molestiae molestiae." },
                    { 8, "Ut.", "Fuga excepturi et vel accusantium id." },
                    { 9, "Iure.", "Aut enim dignissimos alias. Qui corrupti est nemo non est animi. Minima velit excepturi et voluptatem ullam eligendi velit." },
                    { 10, "Et.", "Nulla voluptas voluptatem ad voluptatem impedit quis deleniti eius. Non quam quia id. Nulla reprehenderit ad et autem. Consequatur asperiores ut molestiae ullam." }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "CategoryID", "Description", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 4, "Quia autem aut esse nihil ut optio. Et quo velit sit qui cupiditate. Consequuntur earum sint nobis vel quia.", 1660756665, "Corporis.", 1921120402 },
                    { 2, 3, "Labore ut ea sed minus dolorem placeat eos. Aspernatur quisquam ut tempora voluptatem ab odio exercitationem ex. Dolores totam velit nemo et rerum corrupti et dolorum. Qui quis temporibus dolores. Error quod voluptas atque pariatur ex nihil voluptatem quia.", 1524947334, "Ducimus.", 631977397 },
                    { 3, 4, "Aut laborum molestiae ipsum eum nam quod eveniet dolore ut. Cum fuga est recusandae. Blanditiis cumque enim mollitia vel quas atque molestiae quia. Rerum expedita incidunt officia.", 1445866477, "Cumque.", 178806467 },
                    { 4, 1, "Minus architecto aspernatur officia id illum in. Unde optio accusantium in dignissimos culpa reprehenderit. Neque rem consequuntur alias delectus deserunt omnis dicta nam. Consectetur non nulla blanditiis voluptas possimus magni vero. Ut et tempora ut nam pariatur dolorum est consectetur et.", 1774829784, "Dolor.", 1894802730 },
                    { 5, 2, "Nihil harum eos. Perferendis et rerum fuga commodi. Sunt quis enim ducimus officia laborum sequi aliquam. Similique laudantium voluptatem nisi ut qui praesentium perferendis excepturi molestiae. Voluptas ducimus in impedit nihil modi eum recusandae. Nemo a eaque corrupti aut animi.", 1953955362, "Aut.", 1294259661 },
                    { 6, 9, "Ea qui iste. Labore porro omnis et et. Soluta reiciendis rerum aut. Voluptatem commodi repellendus eius assumenda et laborum. Distinctio laudantium corporis voluptas aut consequatur. Ad ipsam recusandae autem eaque quia accusamus recusandae officia eius.", 71841598, "Quis.", 509912739 },
                    { 7, 8, "Autem sit adipisci commodi voluptatem veritatis ducimus maxime nesciunt. Qui recusandae hic ducimus aspernatur deleniti et commodi ipsa ut. Odio sequi et adipisci repellat fugiat tempora dicta officia at. Ut sint nemo fuga possimus voluptates neque. Molestiae nostrum sapiente aut aut expedita enim atque ullam. Sint dignissimos vero.", 1813872650, "Ut.", 1454586089 },
                    { 8, 6, "Eius distinctio sunt eaque. Officia doloremque qui rem est. Sed ipsum nisi.", 385511450, "Ipsum.", 878802661 },
                    { 9, 5, "Ipsa libero velit nihil expedita consequatur tenetur animi doloribus quod. Facilis nihil harum. Recusandae at et labore nisi dolorem. Et labore est ut enim.", 2016752372, "Qui.", 1552089781 },
                    { 10, 8, "Ut fuga iste recusandae accusantium amet officiis. Enim adipisci cupiditate quidem aut dicta dolore totam. Corrupti aut aut quisquam voluptas quia. Nemo minus architecto.", 262193825, "Debitis.", 953778688 },
                    { 11, 7, "Nemo exercitationem dolores numquam sequi tenetur. Harum quae dolorem impedit voluptatem autem mollitia. Sequi recusandae accusamus consectetur eveniet dolores qui ut fuga nostrum.", 1192687585, "Velit.", 1275493219 },
                    { 12, 4, "Mollitia itaque ipsum laboriosam ad at ratione dolores dolores consequuntur. Mollitia rem veniam nesciunt similique a et ut eius. Aliquid vero possimus.", 1620973432, "Facere.", 1025510689 },
                    { 13, 1, "Corrupti enim adipisci distinctio aut illum. Perferendis ipsa omnis alias voluptas eligendi accusantium qui. A dolorum sed tenetur at alias officiis dolore vitae. Eum aliquid consequatur enim id distinctio.", 336596533, "Voluptatum.", 953886851 },
                    { 14, 4, "Asperiores rerum dolor ea. Non veritatis atque aut eius. Omnis enim corrupti iste atque qui hic culpa reprehenderit maiores. Quia minus voluptatem nisi rerum. Repudiandae dolorum id laudantium vero. Sapiente ut dolorem.", 521041396, "Dolores.", 481535308 },
                    { 15, 10, "A iure velit aut et aut. Sint quis sequi nobis. Ducimus suscipit aut necessitatibus consequatur sunt atque deleniti. Sint quia cupiditate officia expedita aut. Doloremque eaque quidem.", 1009750615, "Dolore.", 757380751 },
                    { 16, 3, "Illum mollitia unde corrupti et. Nostrum vel dolor rerum distinctio. Omnis voluptas aut accusantium eaque dolor cum. Ut et dicta necessitatibus sit.", 1629999056, "Odio.", 1136376393 },
                    { 17, 2, "Veniam nam rerum et molestiae corporis. Exercitationem minima nihil dolorem. Dolores eos exercitationem molestias enim. Est voluptas vitae.", 1412116094, "Illo.", 1618489196 },
                    { 18, 10, "Incidunt et fugiat non. Quos aut modi. Est debitis molestiae repellat. Eius et occaecati quo expedita sit unde aut. Veniam nobis aliquid ut.", 1900216093, "Iure.", 851650110 },
                    { 19, 4, "Quibusdam suscipit sequi. Quis adipisci quis aut esse saepe. Dicta dolorum cum qui eos.", 726868799, "Mollitia.", 1417069011 },
                    { 20, 8, "Possimus occaecati sit nulla hic laboriosam delectus. Recusandae facilis nihil qui consequatur ducimus quis eos voluptatem. Eum iure aliquid ut ut sunt autem quasi hic. Minima autem cumque dolores. Et et pariatur eos dignissimos nesciunt beatae non quas.", 911568839, "Distinctio.", 800514779 },
                    { 21, 3, "Nihil culpa fugiat neque. Corrupti quia labore illo. Reprehenderit dolor omnis iste rerum nostrum et id qui iusto. Qui est facere blanditiis nulla.", 949014846, "Officiis.", 174051601 },
                    { 22, 5, "Tenetur sed corporis. Blanditiis eos tempore fuga iure minima nobis. Tenetur deserunt doloremque delectus. Aperiam illo aut et. Ut beatae impedit sit quis aut in.", 1353827966, "Architecto.", 734074102 },
                    { 23, 4, "Dolor minima soluta voluptas et et sit et nemo saepe. Laboriosam officiis deserunt voluptatem voluptatem est consectetur. Voluptatem modi repudiandae consequuntur voluptas. Modi consequuntur eligendi quis aut dolores doloribus quia reiciendis. Facere quis dolore. Quia rerum aut ea iusto.", 1986993996, "Id.", 507082135 },
                    { 24, 3, "Aliquam cum voluptas ut sequi. Saepe molestiae corporis quidem optio sed in provident magni saepe. Molestias est deleniti recusandae quia molestias non. Est sint voluptate optio praesentium autem architecto.", 1914743610, "Exercitationem.", 286534188 },
                    { 25, 2, "Ex eum officiis consequatur ipsam sed. Ipsam sit harum. Consequatur facilis voluptas. Beatae dolorem omnis omnis laudantium. Atque minus voluptas quaerat dolorum quam ipsum et animi soluta.", 1954650134, "Facere.", 868599818 },
                    { 26, 8, "Nemo et animi architecto veritatis commodi error molestiae earum saepe. Commodi distinctio asperiores dolores praesentium accusamus aspernatur doloremque. Eligendi dolor accusamus sint qui tenetur ad ut. Quo tempora omnis libero expedita qui. In velit libero voluptatum optio consectetur voluptatum minima ratione.", 1329292318, "Corporis.", 1962733179 },
                    { 27, 6, "Possimus quia cupiditate dolor vitae. Aut sunt distinctio aut incidunt. Debitis optio consequatur ut quia veritatis praesentium molestiae.", 1666767967, "Quaerat.", 537566887 },
                    { 28, 8, "Ducimus magni est blanditiis eius quas voluptates qui non doloremque. Et iste iure eaque eius. Laborum enim perspiciatis perferendis. Qui libero et culpa quisquam.", 1834210085, "Consequatur.", 1304807670 },
                    { 29, 7, "Provident magnam est ducimus quis repellendus iste est. Maxime reprehenderit officiis neque aut. Veritatis reiciendis explicabo hic sint.", 903511020, "Pariatur.", 1131417557 },
                    { 30, 9, "Porro quo animi numquam autem placeat quas delectus. Dolorem eveniet possimus blanditiis soluta nesciunt. Voluptate impedit iste optio nihil voluptatem eius dolorum ut quaerat.", 555669767, "Dolor.", 861233822 },
                    { 31, 9, "Saepe blanditiis ratione dolor dolores esse quas ipsam deserunt. Adipisci consectetur praesentium deleniti occaecati magni magnam non modi. Voluptatem error dolorum reiciendis ipsam sed ut. Assumenda aliquid ea nemo dolor facilis temporibus cumque. Incidunt non qui consectetur aut natus voluptate nihil impedit.", 215186515, "Deserunt.", 719261123 },
                    { 32, 4, "Quos sit quo. Et vel voluptatem at. Et qui necessitatibus perferendis vel est illum. Voluptatem quisquam vitae ipsam non.", 1068754171, "Debitis.", 478818795 },
                    { 33, 10, "Deleniti deleniti earum aut sequi blanditiis et id. Fugiat asperiores laboriosam natus ipsam. Sed optio maiores ipsam excepturi quo pariatur nesciunt quis omnis. Quia fuga et quaerat veritatis.", 119777914, "Quaerat.", 164574380 },
                    { 34, 8, "Incidunt tenetur placeat expedita rerum dicta aut est. Aliquam sit voluptates sit rerum vel doloribus harum. Expedita nisi officiis magni labore. Odit assumenda odit consequatur quo iste maiores officia repellendus quia. Natus sapiente adipisci. Velit repellendus et quidem quis.", 432056392, "Rerum.", 1856916111 },
                    { 35, 1, "Quis similique repellendus aut quo possimus unde sed. Neque itaque dolores ut molestiae quia aut et aliquam accusantium. Ab praesentium iste et dolores accusamus.", 652074534, "Vero.", 1117689142 },
                    { 36, 8, "Corporis eius sed voluptatibus nulla. Facilis sequi numquam dolorum. Quas aut ipsum tempora quisquam architecto laudantium fugiat. Mollitia eum aut perspiciatis id voluptas consequatur quibusdam.", 1155493114, "Vero.", 1147587207 },
                    { 37, 7, "Rem rerum voluptate qui autem eveniet et recusandae omnis asperiores. Modi non voluptatem dicta harum voluptatem id quod rem. Asperiores autem consequatur quo.", 162827538, "Recusandae.", 1498045861 },
                    { 38, 2, "Quia dolore consectetur. Perferendis saepe optio. Architecto asperiores laborum beatae qui ut possimus.", 1859614369, "Autem.", 1010944332 },
                    { 39, 1, "Molestias in voluptatibus rerum qui pariatur. Itaque velit deserunt dolor quia architecto. Sunt consequatur voluptas ipsa rerum dolores alias voluptas molestiae optio. Quia nam fugit iste qui reiciendis iure. Assumenda nobis expedita aperiam hic debitis minus eligendi.", 1013914778, "Et.", 555245792 },
                    { 40, 1, "Ab dolores voluptatem assumenda natus deleniti maxime rem veniam. Et amet ut vel autem. Temporibus in nemo numquam sint aut necessitatibus. Voluptatem dignissimos rerum aliquid. Minus occaecati rerum eum magnam quas. Eum dolorum quasi quis itaque sit placeat qui.", 669491275, "Soluta.", 1532065032 },
                    { 41, 3, "Autem dolorum rerum beatae et maiores. Fugit provident reprehenderit doloremque omnis nulla vero. Perferendis debitis est temporibus dolorem.", 1620992452, "Et.", 1368023296 },
                    { 42, 10, "Sit enim ipsam in iste aperiam ut. Corporis nihil ducimus voluptas. Tenetur possimus unde. Adipisci id sint consectetur. Quibusdam ut beatae consequatur aut ea. Non at recusandae adipisci aut.", 1179737128, "Nemo.", 991246608 },
                    { 43, 8, "Impedit qui labore rerum. Iste voluptatem est culpa. Sunt enim esse. Voluptatum delectus dolores omnis veritatis et vero. Sunt excepturi est.", 2143326818, "Consequatur.", 543168904 },
                    { 44, 9, "Aperiam nihil nisi aut dolores voluptas esse aspernatur dolorum harum. Commodi molestiae mollitia dolores temporibus aut tenetur odio placeat. Exercitationem et aut est ullam dolorem cumque voluptas. Aut dolorem facilis ut vel. Magni vero commodi impedit facilis consequatur ut praesentium quod voluptatem. In ea nihil ea maxime omnis dolor ut.", 279883773, "Sed.", 577499520 },
                    { 45, 5, "Commodi facere alias porro in. Mollitia expedita aliquam deserunt. Aut debitis veritatis sequi eos in in voluptas. Veritatis eveniet dolores et totam. Rerum consequatur libero.", 1582197419, "Cum.", 1039087280 },
                    { 46, 10, "Et ratione sit omnis ab odit sequi doloremque. Ea cum recusandae. Consequatur voluptatem repudiandae quis enim. Dolorum itaque magnam laudantium in repellendus. Dolor et cumque quia qui consectetur ducimus in qui molestiae.", 1699118533, "Accusamus.", 1085597501 },
                    { 47, 9, "Sapiente debitis nisi nam voluptatem sed iste non in. Aut sit nobis. Reiciendis inventore quia sunt voluptas ut sapiente. Atque molestiae nam fugiat sit temporibus.", 796171569, "Eaque.", 384644662 },
                    { 48, 2, "Facilis fugit et culpa et amet temporibus ea deserunt sapiente. Reiciendis id hic totam necessitatibus impedit quos temporibus. Qui quam repellat molestiae temporibus voluptas. Est ducimus et quia aut doloribus quasi esse non quis. Veniam omnis optio quia sit nihil explicabo aliquid.", 1274065743, "Impedit.", 1300155834 },
                    { 49, 4, "Excepturi modi fugit autem. Pariatur incidunt et repudiandae est rerum voluptas maiores sed. Quaerat animi a quia aut omnis enim. Nostrum suscipit iusto. Facilis excepturi eligendi quo tenetur illo nulla. Consectetur explicabo repudiandae sapiente iusto perspiciatis harum.", 848122986, "Consequatur.", 1146140002 },
                    { 50, 1, "Voluptatem ut neque voluptates consequatur labore dolores dolorem eaque aliquid. Officia omnis eius aut nobis. Qui reiciendis nisi dolorem est repellat est laudantium. Veritatis ducimus tempora aut. Non officiis natus. Deleniti autem ratione deleniti voluptatem inventore ut.", 135417118, "Et.", 1252130265 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
