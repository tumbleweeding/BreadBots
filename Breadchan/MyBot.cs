using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Discord;
using Discord.Commands;

namespace BOT_Bread
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        string[] facts;
        Random rnd;

        int numberOfMessages = 0;

        private static System.Timers.Timer msgTimer;

        public MyBot()
        {
            rnd = new Random();

            msgTimer = new Timer { Interval = 60000 }; // in milliseconds
            msgTimer.Elapsed += (s, e) =>
            {
                if(numberOfMessages >= 0)
                {
                    numberOfMessages--;
                }
            };
            msgTimer.Start();



            facts = new string[]
            {
                "Did you know that it takes 9 seconds for a combine to harvest enough wheat to make around 70 loafs of Bread?",
                "In Scandinavian traditions, if a boy and girl eat from the same loaf, they are bound to fall in love... :/3",
                "Did you know that Bread was used as a type of currency in Ancient Egypt?",
                "In 1997, Kansas wheat farmers produced enough wheat to make 36.5 billion loaves of Bread! Enough to provide each person on Earth with 6 loaves.",
                "Did you know that in 1943, a member of the U.S. government decided to ban sliced Bread?",
                "On average, an American consumes 53 pounds of Bread per year! :O",
                "Did you know that Bread is Pain in French?",
                "Mankind has been eating Bread since at least 10,000 B.C.E!",
                "Did you know that in Ancient Egypt, Bread was so revered, it would be place in the tombs of the dead.",
                "One superstition is that if you place Bread in a baby's caradle, it will keep away illness!",
                "Did you know that the inner part of the Bread within the crust is called the 'crumb'? Which is why small bits of Bread are called 'crumbs'.",
                "One bushel of wheat can produce 73 one-pound loaves of Bread!",
                "The ancient Greeks produced more than 80 types of Bread in 2500 B.C.E! That's a lot of different Breads! :3",
                "September 16th is National Cinnamon Raisin Bread Day! Cook some for your family and friends! <3",
                "National law dictates that French Bread should contain only flour, yeast, salt, and water!",
                "Pablo Neruda once said, 'Peace goes into the making of a poem as flour goes into the making of bread.'",
                "Is a Bread pan... just a Bread Bread??? >:O",
                "Sandwiches account for 50% of Bread consumption, whether bought or home-made!",
                "Farmers receive approximately 5 cents (or less) from each loaf of Bread sold...",
                "Did you know that hard Bread can be used as a weapon? >:3",
                "Bread is probably the one food that is eaten by people of every race, culture, and religion! Hooray Bread!",
                "Jean Anouilh once said, 'I like reality. It tastes like Bread.' It's true! :3",
                "The German word for Bread is Brot!",
                "During World War II, the National Research Council asks the Bread and milling industries to add more nutrients to their flour and Bread to prevent wartime malnutrition!",
                "The yeast used in most Breads is called Saccharomyces Cerevisiae! It's Latin for 'sugar fungus'! :3",
                "It is bad luck to turn a loaf of Bread upside down... So don't do it!",
                "In 2007, the Maine Grain Alliance held its first ever Kneading Conference to promote the return to local grains and milling! They really kneaded it! :3",
                "As tempting as it is, do not feed Bread to the ducks and swans in the pond! Bread does not provide the nutrients they need! :c",
                "The Wonder Bread was America's first nationally distributed sliced Bread!",
                "Bill Cosby once said, 'I am proud to be an American. Because an American can eat anything on the face of this earth as long as he has two pieces of Bread.' Kinda mean...",
                "Bread absorbs water really well! So avoid Bread to stay hydrated... But eat Bread anyways :3",
                "It is bad luck to cut an unbaked loaf of Bread... So make sure you bake it first!",
                "The first grain grinding stone was invented by the Egyptians around 8000 B.C.E!",
                "February 23rd is National Banana Bread Day! Make some for your loved ones! <3",
                "Pumpernickel is rarely found inside a bakery! It is steamed, not baked! :P",
                "In 1700s, Earl of Sandwich named the sandwich!",
                "Whoever eats the last piece of Bread has to kiss the cook. 0w0",
                "60% of the flour in the UK is used to make Bread!",
                "A Chinese proverb goes - 'If you have two loaves of Bread, sell one and buy a lily'.",
                "Bread molds really quickly, so make sure you store it in a cool dry place to avoid mold!",
                "In Ren and Stimpy, there's a superhero called Powered Toastman! He's silly. :3",
                "In Paris, there is an annual competition for the best baguette baker! How cool is that!?!",
                "Bread craftsmanship in Germany is so prestigeous that you need much training before becoming a Baeckermeister, Master Baker! :O",
                "Bread is so important to French cuisine, laws up until 2014 didn't allow all bakers in Paris to take summer holidays at the same time! Bread always come first! >:D",
                "In 1995, a team of bakers from Wheat Montana Farms and Bakery harvested wheat and baked a loaf of Bread in 8 minutes, 13 seconds! That's super fast!",
                "Bread is Pan in Spanish. And in Japanese. And in Galician. And in French. Is Peter Pan Peter Bread?",
                "All Toasters Toast Toast.",
                "The shape of baguette allows more dough to be exposed during the baking process, producing a thick crust!",
                "Bread is so important in Germany that they have a word for Abendbrot - evening bread and Brotzeit - snack bread time. ('v')/",
                "Napoleon created the term 'pumpernickle', when he ordered 'Pain pour Nicole', 'Bread for Nicole (His horse)'.",
                "Did you know that stale FlatBread can be used as sandpaper? >:3",
                "December 22nd is National Date Nut Bread Day. Perfect for Christmas! <3",
                "According to Murphy's Law, a buttered Bread will always land butter-side down! :c",
                "Germany is 'Bread Paradise' with over 3050 different recipes from the county's bakers. I wish I lived there! -3-",
                "Mcdonald's burger buns contained so much sugar, that their burgers are considered a pastry in France! Thier employees must be pastries too because they're so sweet... c/:",
                "Stale Bread is sometimes stale good! Just make sure you cut off the moldy parts! :3",
                "March 21st is National French Bread Day! Baguette day! <3",
                "Baguette means Stick or Baton in French. Truly a dangerous weapon...",
                "In medieval times, Bread were named after the ranks of people who ate it! Common loafs, squire's loaf, court's loaf, knight's loaf... TopDylan's loaf... c:",
                "In France, a law was passed in 1920, banning bakers from starting work before 4am and no later than 10pm. So they made the baguette, as a fast-baked solution!",
                "In 2005, Fry Bread was declared the Offical Bread of South Dakota! Good for him! :D",
                "In 1890, women at home backed over 80% of the bread eaten in the U.S. But in the late 1920s, 94% of bread was baked by men in commerical bakeries!",
                "January is Wheat Bread Month! It is also Bread Machine Baking Month! <3",
                "There's a Plain Bread-chan in the anime, Bobobo-bo Bo-bobo! Not as cute though :/3",
                "Imako-chan is the real bread overlord. Heil Imako-chan!",
                "Dylan fantasizes about bread daily!"
            };
         
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '~';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterFactCommand();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi!");
                });

            commands.CreateCommand("say goodnight")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Goodnight, friends!");
                });

            commands.CreateCommand("say goodnight")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Goodnight, friends!");
                });

            commands.CreateCommand("I'm fine! How about you, Bread-chan?")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I'm doing well! How about you, Carlos?");
                });

            commands.CreateCommand("bread fact")
                .Do(async (e) =>
                {
                    if (numberOfMessages > 4)
                    {
                        await e.Channel.SendMessage("Relax! Don't work me too hard ★~(◠︿◕✿)");
                    } else {
                        int rndFact = rnd.Next(facts.Length);
                        string factToPost = facts[rndFact];
                        await e.Channel.SendMessage(factToPost);
                        if(numberOfMessages < 6)
                        {
                            numberOfMessages++;
                        }
            
                    }
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("the token goes here. i keep the token secret", TokenType.Bot);
            });
        }

        private void RegisterFactCommand()
        { }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
