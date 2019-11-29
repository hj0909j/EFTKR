using Discord;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Net;

namespace discordnetbot
{
    public class Program
    {
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.Log += Log;
            string token = "NjI2OTE0NTI5NDg1MjU4ODA1.XboyRg.cLf6I5PLAyRKvMpob6ZjylOVhV4"; //고유 토큰
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            client.MessageReceived += MessageReceived;
            client.Ready += Client_Ready;
            client.GuildAvailable += Client_GuildAvailable;
            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지
        }

        private Task Client_GuildAvailable(SocketGuild arg)
        {
            //arg.DefaultChannel.SendMessageAsync("On");
            return Task.CompletedTask;
        }

        private Task Client_Ready() { return Task.CompletedTask; }

        //bool active = false;

        //도움말
        private async Task MessageReceived(SocketMessage message)
        {
            //////////Help Command/////////////
            if (message.Content == "!Help" || message.Content == "!help" || message.Content == "!command" || message.Content == "!Command")
            {
                await message.Channel.SendMessageAsync("**Donate Discord Truck#7166**");

                await message.Channel.SendMessageAsync("```if you want watching map enter the '!map' or !lab...\n\n" +
                                                       "'!Shoreline'-> loading map(ShoreLine) \n" +
                                                       "'!delete 10' -> 10 message delete (limit 100)\n" +
                                                       "'!task or !quest -> print command\n" +
                                                       "'!Donate'  -> Donate list'```");

                await message.Channel.SendMessageAsync("```'!Ammo' -> ammo command\n" +
                                                       "'!M4A1' -> print M4A1's Ammo chart\n" +
                                                       "'!5.45' -> print 5.45x39's Ammo chart" +
                                                       "'!bestammo` -> type of bestammo```");

                await message.Channel.SendMessageAsync("```!AR  -> AssultRifle\n!DMR -> AssultCarbine\n!SR  -> SniperRifle!SMG -> SubMachinegun\n!pistol\n!SG - > Shotgun```");
            }

            if (message.Content == "!FREE TRUCK")
            {
                await message.Channel.SendMessageAsync("**후원 해주세요오오오오오**");
            }

            if (message.Content == "!Donate")
            {
                await message.Channel.SendMessageAsync("**후원받은 금액은 서버 호스팅에 사용합니다**");

                await message.Channel.SendMessageAsync("**3520923030223 농협 김*진**");

                await message.Channel.SendMessageAsync("**현재 후원금액 : 13000원\n" +
                                                       "후원자 : 재리님, K2C님, 해마티엘님**");
            }

            if (message.Content == "!quest" || message.Content == "!task")
            {
                await message.Channel.SendMessageAsync("```" +
                                                        "\nSkier's       quest list : !qski" +
                                                        "\nPrapor's      quest list : !qpra" +
                                                        "\nJaeger's      quest list : !qjae" +
                                                        "\nRagman's      quest list : !qrag" +
                                                        "\nMechanic's    quest list : !qmec" +
                                                        "\nTherapist's   quest list : !qthe" +
                                                        "\nPeacekeeper's quest list : !qpea" +
                                                        "```");
                await message.Channel.SendMessageAsync("```Quest Item list : !questItems```");
            }

            ///task item
            if (message.Content == "!questItems" || message.Content == "!questitem")
            {
                await message.Channel.SendFileAsync("Asset/Tip/Quest Item.PNG");
            }

            //////////Delete Message///////////
            {
                string str0 = "!delete ";
                string str1 = "!Delete ";
                for (int num = 0; num < 100; num++)
                {
                    if (message.Content == str0 + num.ToString() || message.Content == str1 + num.ToString())
                    {

                        IEnumerable<IMessage> m = await message.Channel.GetMessagesAsync(num + 1).FlattenAsync();

                        await ((SocketTextChannel)message.Channel).DeleteMessagesAsync(m);

                        break;
                    }
                }
            }

            ////////////gun part///////////////
            {

                //string[] AssultCarbine    = { "VSS", "SKS", "OP-SKS", "AS VAL" };
                //string[] AssultRifle      = {"AK-74U", "VPO-209", "VPO-136", "AK-101", "M4A1", "HK-416A5", "AKS-74UN", "AKS-74UB", "ADAR 2-15", "AKS-74N", "AKM", "AK-104", "AK-105",
                //                                       "AKMSN", "AK-103", "AK-74N", "AK-74M", "AKMN", "AKMS" };
                //string[] MarksmanRifle    = { "RSASS", "M1A", "SA-58" };
                //string[] SniperRifle      = { "Mosin Infantry", "Mosin", "M700", "DVL-10" };
                //string[] SubmachineGun    = { "PP-91-01 Kedr-B", "PP-91 Kedr", "PP-91 Klin", "PP-19-01", "MPX", "Saiga-9", "MP7A2", "MP7A1", "MP5", "P90" };
                //string[] ShotGun = { "Saiga 12ga", "TOZ-106", "MP-153", "M870", "MR-133" };
                //string[] HandGun = { "GLOCK18C", "P226R", "SR-1MP", "MP-443 Grach", "TT", "PM (t)", "PM", "GLOCK17", "PB", "APS", "FN 5-7" };

                string[] _545x39 = { "AK-74U", "AKS-74N", "AKS-74UN", "AKS-74UB", "AK-74N", "AK-105", "AK-74M", "RPK-16" };

                string[] _556x45 = { "M4A1", "HK-416A5", "ADAR 2-15", "AK-101", "AK-102" };

                string[] _762x39 = { "VPO-136", "AKMSN", "AK-103", "AKM", "AK-104", "AKMN", "AKMS", "SKS", "OP-SKS" };

                string[] _366 = { "VPO-209" };

                string[] _127x55 = { "ASH" };

                string[] _762x51 = { "SA-58", "RSASS", "M1A", "M700", "DVL-10", "Hunter" };

                string[] _762x54R = { "SVDS", "Mosin", "Mosin Inf", "SV-98" };

                string[] _9x19mm = { "GLOCK17", "GLOCK18C", "M9A3", "MP-443", "P226R", "MP5", "MP5K-N", "MPX", "PP-19-01", "Saiga-9" };

                string[] _57x28mm = { "FN 5-7", "P90" };

                string[] _9x18mm = { "PP-91", " PM (t)", "PM", "PB", "APS", "APB" };

                string[] _9x21mm = { "SR-1MP" };

                string[] _9x39mm = { "VSS", "AS VAL" };

                string[] _46x30mm = { "MP7A1", "MP7A2" };

                string[] _12Guage = { "M870", "MP-133", "MP-153", "Saiga-12" };

                string[] _20Guage = { "TOZ-106" };

                if (message.Content == "!AssultRifle" || message.Content == "!AR")
                {
                    await message.Channel.SendMessageAsync("```(5.45x39mm) AK-74U, AKS-74, AK-74, AKS-74N, AKS-74UN, AKS-74UB, AK-74N, AK-105, AK-74M, RPK-16\n" +
                                                              "(.366 TKM)  VPO-209\n" +
                                                              "(7.62x39mm) VPO-136, AKMSN, AK-103, AKM, AK-104, AKMN, AKMS\n" +
                                                              "(5.56x45mm) M4A1, HK-416A5, ADAR 2-15, AK-101, AK-102, TX-15 DML, DT MDR```");
                }

                if (message.Content == "!SubmachineGun" || message.Content == "!SMG")
                {
                    await message.Channel.SendMessageAsync("```(9x18mm)   PP-91-01 Kedr-B, PP-91 Kedr, PP-91 Klin -> PP-91\n" +
                                                              "(9x19mm)   PP-19-01, MPX, mp5, Saiga-9\n" +
                                                              "(4.6x30mm) MP7A2, MP7A1\n" +
                                                              "(5.7x28mm) P90```");
                }

                if (message.Content == "!Handgun" || message.Content == "!Pistol" || message.Content == "!pistol")
                {
                    await message.Channel.SendMessageAsync("```(9x19mm)   GLOCK18C, GLOCK17, P226R, MP-443, M9A3, P226R\n" +
                                                              "(7.62x25)  TT\n" +
                                                              "(9x21mm)   SR-1MP\n" +
                                                              "(9x18mm)   PM (t), PM, PB, APS, APB\n" +
                                                              "(5.7x28mm) FN 5-7```");
                }

                if (message.Content == "!AssultCarbine" || message.Content == "!DMR")
                {
                    await message.Channel.SendMessageAsync("```(7.62x39) SKS, OP-SKS,\n" +
                                                              "(9x39)    VSS, AS VAL\n" +
                                                              "(7.62x51) SA-58, RSASS, M1A, Vepr Hunter/VPO-101(Hunter)```");
                }

                if (message.Content == "!SR" || message.Content == "SniperRifle")
                {
                    await message.Channel.SendMessageAsync("```(7.62x51)  DVL-10\n" +
                                                              "(7.62x54R) Mosin, Mosin Inf, M700, SV-98```");
                }

                if (message.Content == "!Shotgun" || message.Content == "!SG")
                {
                    await message.Channel.SendMessageAsync("```(12Guage) M870, MP-133, MP-153, Saiga-12\n(20Guage) TOZ-106```");
                }

                if (message.Content == "!Ammo" || message.Content == "!ammo")
                {
                    await message.Channel.SendMessageAsync("```!12.7\n!12Guage\n!20Guage\n!366\n!4.6x30\n!5.45\n!5.56\n!7.62x25\n!7.62x39\n!7.62x51\n!7.62x54R\n!9x18\n!9x19\n!9x21\n!9x39```");

                    await message.Channel.SendMessageAsync("**!bestammo**");

                }

                if (message.Content == "!bestammo" || message.Content == "!BestAmmo")
                {
                    await message.Channel.SendFileAsync("Asset/EFT BULLET/BestAmmo.PNG");

                }

                //Error for 7.62mm is so many
                if (message.Content == "!7.62")
                {
                    await message.Channel.SendMessageAsync("```please command !7.62x25 !7.62x39 or !7.62x51 or !7.62x54R```");
                }

                //print 7.62x39mm ammo chart
                for (int i = 0; i < _762x39.Length; i++)
                {
                    if (message.Content == "!" + _762x39[i] || message.Content == "!7.62x39")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/7.62x39mm.PNG");

                        break;
                    }
                }

                //print 7.62x51mm ammo chart
                for (int i = 0; i < _762x51.Length; i++)
                {
                    if (message.Content == "!" + _762x51[i] || message.Content == "!7.62x51")
                    {

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/7.62x51mm.PNG");

                        break;
                    }
                }

                //print 7.62x54Rmm ammo chart
                for (int i = 0; i < _762x54R.Length; i++)
                {
                    if (message.Content == "!" + _762x54R[i] || message.Content == "!7.62x54R")
                    {

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/7.62x54R.PNG");

                        break;
                    }
                }

                //print 5.45x39mm ammo chart
                for (int i = 0; i < _545x39.Length; i++)
                {
                    if (message.Content == "!" + _545x39[i] || message.Content == "!5.45")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/5.45x39mm.PNG");

                        break;
                    }
                }

                //print 5.56x45mm ammo chart
                for (int i = 0; i < _556x45.Length; i++)
                {
                    if (message.Content == "!" + _556x45[i] || message.Content == "!5.56")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/5.56x45mm.PNG");

                        break;
                    }
                }

                //print 9x19mm ammo chart
                for (int i = 0; i < _9x19mm.Length; i++)
                {

                    if (message.Content == "!" + _9x19mm[i] || message.Content == "!9x19")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/9x19mm.PNG");

                        break;
                    }
                }

                //print 9x18mm ammo chart
                for (int i = 0; i < _9x18mm.Length; i++)
                {

                    if (message.Content == "!" + _9x18mm[i] || message.Content == "!9x18")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/9x18mm.PNG");

                        break;
                    }
                }

                //print 9x21mm ammo chart
                for (int i = 0; i < _9x21mm.Length; i++)
                {

                    if (message.Content == "!" + _9x21mm[i] || message.Content == "!9x21")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/9x21mm.PNG");

                        break;
                    }
                }

                //print 9x39mm ammo chart
                for (int i = 0; i < _9x39mm.Length; i++)
                {

                    if (message.Content == "!" + _9x39mm[i] || message.Content == "!9x39")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/9x39mm.PNG");

                        break;
                    }
                }

                //print FN 5.7x28mm
                for (int i = 0; i < _57x28mm.Length; i++)
                {
                    if (message.Content == "!" + _57x28mm[i] || message.Content == "!5.7x28")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/5.7x28mm.PNG");

                        break;
                    }
                }

                //print 4.6x30mm
                for (int i = 0; i < _46x30mm.Length; i++)
                {
                    if (message.Content == "!" + _46x30mm[i] || message.Content == "!4.6x30")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/4.6x30mm.PNG");

                        break;
                    }
                }

                //print 12Guage
                for (int i = 0; i < _12Guage.Length; i++)
                {
                    if (message.Content == "!" + _12Guage[i] || message.Content == "!12Guage")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/12Guage.PNG");

                        break;
                    }
                }

                //print 20Guage
                for (int i = 0; i < _20Guage.Length; i++)
                {
                    if (message.Content == "!" + _20Guage[i] || message.Content == "!20Guage")
                    {
                        await message.Channel.SendFileAsync("Asset/EFT BULLET/Main.PNG");

                        await message.Channel.SendFileAsync("Asset/EFT BULLET/20Guage.PNG");

                        break;
                    }
                }

                //print 12.7x55mm
                for (int i = 0; i < _127x55.Length; i++)
                {
                    if (message.Content == "!" + _127x55[i] || message.Content == "!12.7")
                    {
                        await message.Channel.SendFileAsync("Asset\\EFT BULLET\\Main.PNG");

                        await message.Channel.SendFileAsync("Asset\\EFT BULLET\\12.7x55mm.PNG");

                        break;
                    }
                }

            }

            /////////////Map part//////////////
            {
                if (message.Content == "!shoreline" || message.Content == "!Shoreline")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/ShoreLine/ShoreLine01.JPG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/ShoreLine/ShoreLine02.PNG");
                }
                else if (message.Content == "!shoreLine" || message.Content == "!ShoreLine")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/ShoreLine/ShoreLine01.JPG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/ShoreLine/ShoreLine02.PNG");
                }

                if (message.Content == "!interchange" || message.Content == "!Interchange")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/InterChange/InterChange01.PNG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/InterChange/InterChange02.PNG");
                }
                else if (message.Content == "!InterChange")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/InterChange/InterChange01.PNG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/InterChange/InterChange02.PNG");
                }

                if (message.Content == "!lab" || message.Content == "!Lab")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/Lab/Lab01.PNG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/Lab/Lab02.PNG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/Lab/Lab03.PNG");
                }

                if (message.Content == "!custom" || message.Content == "!Custom")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/Custom/Custom01.PNG");

                    await message.Channel.SendFileAsync("Asset/EFT MAP/Custom/Custom02.PNG");
                }

                if (message.Content == "!Woods" || message.Content == "!woods")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/Woods/Woods01.JPG");
                }

                if (message.Content == "!Reserve" || message.Content == "!reserve")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/Reserve/Reserve01.PNG");
                }

                if (message.Content == "!Factory" || message.Content == "!factory")
                {
                    await message.Channel.SendFileAsync("Asset/EFT MAP/Factory/Factory01.PNG");
                }


                //맵
                if (message.Content == "!map" || message.Content == "!Map")
                {
                    await message.Channel.SendMessageAsync("```!Lab\n!InterChange\n!ShoreLine\n!Custom\n!Woods\n!Factory\n!Reserve\n```");
                }

            }

            ///////////Taskk part//////////////
            {

                //prapor
                string[] qpra = {"Debut", "Checking", "Shootout_picnic", "Delivery_from_the_past", "BP_deport", "Bad_rep_evidence", "Ice_cream_cones", "Postman_pat_-_part_1",
                                 "Shaking_up_teller", "The_Punisher_-_part_1", "The_Punisher_-_part_2", "The_Punisher_-_part_3", "The_Punisher_-_part_4", "The_Punisher_-_part_5", "The_Punisher_-_part_6",
                                 "Polikhim_hobo", "Big_customer", "No_offence", "Grenadier", "Perfect_mediator", "Insomnia","Test_drive_-_part_1","Regulated_maeterials"};

                if (message.Content == "!qpra")
                {
                    await message.Channel.SendMessageAsync("```!Debut\n!Checking\n!Shootout_picnic\n!Delivery_from_the_past\n!BP_deport\n!Bad_rep_evidence\n!Ice_cream_cones\n!Postman_Pat_-_part_1\n" +
                                                           "!Shaking_up_teller\n!The_Punisher_-_part1\n!The_Punisher_-_part_2\n!The_Punisher_-_part_3\n!!The_Punisher_-_part_4\n!The_Punisher_-_part_5\n!The_Punisher_-_part_6\n" +
                                                           "!Polikhim_hobo\n!Big_customer\n!No_offence\n!Grenadier\n!Perfect_mediator\n!Insomnia\n!Test_drive_-_part_1\n!Regulated_maeterials```");
                }

                for (int i = 0; i < qpra.Length; i++)
                {
                    if (message.Content == "!" + qpra[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qpra[i]);
                        break;
                    }
                }

                //mechanic
                string[] qmec = { "Gunsmith_-_Part_1","Gunsmith_-_Part_2", "Gunsmith_-_Part_3" , "Gunsmith_-_Part_4" , "Gunsmith_-_Part_5" ,"Gunsmith_-_Part_6", "Gunsmith_-_Part_7", "Gunsmith_-_Part_8",
                                  "Gunsmith_-_Part_9","Gunsmith_-_Part_10","Gunsmith_-_Part_11","Gunsmith_-_Part_12","Gunsmith_-_Part_13","Gunsmith_-_Part_14","Gunsmith_-_Part_15","Gunsmith_-_Part_16",
                                  "Farming_-_Part_1", "Farming_-_Part_2", "Farming_-_Part_3", "Farming_-_Part_4","Signal_-_Part_1", "Signal_-_Part_2", "Signal_-_Part_3", "Signal_-_Part_4", "Bad_habit",
                                  "Scout", "Insider", "Psycho_Sniper", "Import", "Fertilizers", "A_Shooter_Born_in_Heaven", "Introduction"};

                if (message.Content == "!qmec")
                {
                    await message.Channel.SendMessageAsync("```!Gunsmith_-_Part_1\n!Gunsmith_-_Part_2\n!Gunsmith_-_Part_3\n!Gunsmith_-_Part_4\n!Gunsmith_-_Part_5\n!Gunsmith_-_Part_6\n" +
                                                           "!Gunsmith_-_Part_7\n!Gunsmith_-_Part_8\n!Gunsmith_-_Part_9\n!Gunsmith_-_Part_10\n!Gunsmith_-_Part_11\n!Gunsmith_-_Part_12\n!Gunsmith_-_Part_13\n!Gunsmith_-_Part_14\n" +
                                                           "!Gunsmith_-_Part_15\n!Gunsmith_-_Part_16\n!Farming_-_Part_1\n!Farming_-_Part_2\n!Farming_-_Part_3\n!Farming_-_Part_4\n!Signal_-_Part_1\n!Signal_-_Part_2\n!Signal_-_Part_3\n" +
                                                           "!Signal_-_Part_4\n!Bad_habit\n!Scout\n!Insider\n!Psycho_Sniper\n!Import\n!Fertilizers\n!A_Shooter_Born_in_Heaven\n!Introduction```");
                }
                for (int i = 0; i < qmec.Length; i++)
                {
                    if (message.Content == "!" + qmec[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qmec[i]);
                        break;
                    }
                }

                //Therapist
                string[] qthe = { "Shortage", "Sanitary_Standards_-_Part_1", "Sanitary_Standards_-_Part_2", "Operation_Aquarius_-_Part_1", "Operation_Aquarius_-_Part_2", "Painkiller", "Pharmacist", "Supply_plans",
                        "General_wares", "Car repair", "Health_Care_Privacy_-_Part_1", "Health_Care_Privacy_-_Part_2", "Health_Care_Privacy_-_Part_3", "Health_Care_Privacy_-_Part_4", "Health_Care_Privacy_-_Part_5",
                        "Postman_Pat_-_Part_2", "Out_of_curiosity", "Trust_regain", "Hippocratic_Vow", "Private_clinic", "Athlete", "Decontamination_service", "An_apple_a_day_-_keeps_the_doctor_away"};
                if (message.Content == "!qthe")
                {
                    await message.Channel.SendMessageAsync("```!Shortage\n!Sanitary_Standards_-_Part_1\n!Sanitary_Standards_-_Part_2\n!Operation_Aquarius_-_Part_1\n!Operation_Aquarius_-_Part_2\n!Painkiller\n!Pharmacist\n!Supply_plans\n" +
                        "!General_wares\n!Car repair\n!Health_Care_Privacy_-_Part_1\n!Health_Care_Privacy_-_Part_2\n!Health_Care_Privacy_-_Part_3\n!Health_Care_Privacy_-_Part_4\n!Health_Care_Privacy_-_Part_5\n" +
                        "!Postman_Pat_-_Part_2\n!Out_of_curiosity\n!Trust_regain\n!Hippocratic_Vow\n!Private_clinic\n!Athlete\n!Decontamination_service\n!An_apple_a_day_-_keeps_the_doctor_away```");
                }

                for (int i = 0; i < qthe.Length; i++)
                {
                    if (message.Content == "!" + qthe[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qthe[i]);
                        break;
                    }
                }

                //Skier
                string[] qski = {"Supplier", "The_Extortionist", "Stirrup",/*"What%27s_on_the_flash_drive%3F",*/ "Golden_swag", "Chemical_-_Part_1", "Chemical_-_Part_2", "Chemical_-_Part_3", "Chemical_-_Part_4",
                        "Loyalty_buyout", /*"Vitamins_-_Part_1", "Vitamins_-_Part_2"*/ "Lend_lease_-_Part_1", "Informed_means_armed", "Chumming", "Kind_of_sabotge", "Slient_caliber", "Flint", "Bullshit", "Setup" };

                if (message.Content == "!qski")
                {
                    await message.Channel.SendMessageAsync("```!Supplier\n!The_Extortionist\n!Stirrup\n!What's_on_the_flash_drive?\n!Golden_swag\n!Chemical_-_Part_1\n!Chemical_-_Part_2\n!Chemical_-_Part_3\n!Chemical_-_Part_4\n" +
                        "!Loyalty_buyout\n!Vitamins_-_Part_1\n!Vitamins_-_Part_2\n!Lend_lease_-_Part_1\n!Informed_means_armed\n!Chumming\n!Kind_of_sabotge\n!Slient_caliber\n!Flint\n!Bullshit\n!Setup```");
                }

                for (int i = 0; i < qski.Length; i++)
                {
                    if (message.Content == "!" + qski[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qski[i]);
                        break;
                    }

                }

                //Peacekeeper
                string[] qpea = {"Fishing_Gear", "Tigri_Safari", "Scrap_Metal", "Eagle_Eye", "Humanitarian_Supplies", "The_Cult_-_Part_1","The_Cult_-_Part_2", "Spa_Tour_-_Part_1","Spa_Tour_-_Part_2","Spa_Tour_-_Part_3",
                        "Spa_Tour_-_Part_4", "Spa_Tour_-_Part_5", "Spa_Tour_-_Part_6", "Spa_Tour_-_Part_7", "Cargo_X_-_Part_1", "Cargo_X_-_Part_2", "Cargo_X_-_Part_3", "Lend_lease_-_Part_2", "Wet_Job_-_Part_1", "Wet_Job_-_Part_2",
                        "Wet_Job_-_Part_3", "Wet_Job_-_Part_4", "Wet_Job_-_Part_5","Wet_Job_-_Part_6", "The_guide", "Peacekeeping_mission" };

                if (message.Content == "!qpea")
                {
                    await message.Channel.SendMessageAsync("```!Fishing_Gear\n!Tigri_Safari\n!Scrap_Metal\n!Eagle_Eye\n!Humanitarian_Supplies\n!The_Cult_-_Part_1\n!The_Cult_-_Part_2\n!Spa_Tour_-_Part_1\n!Spa_Tour_-_Part_2\n!Spa_Tour_-_Part_3\n" +
                            "!Spa_Tour_-_Part_4\n!Spa_Tour_-_Part_5\n!Spa_Tour_-_Part_6\n!Spa_Tour_-_Part_7\n!Cargo_X_-_Part_1\n!Cargo_X_-_Part_2\n!Cargo_X_-_Part_3\n!Lend_lease_-_Part_2\n!Wet_Job_-_Part_1\n!Wet_Job_-_Part_2\n" +
                            "!Wet_Job_-_Part_3\n!Wet_Job_-_Part_4\n!Wet_Job_-_Part_5\n!Wet_Job_-_Part_6\n!The_guide\n!Peacekeeping_mission```");
                }

                for (int j = 0; j < qpea.Length; j++)
                {
                    if (message.Content == "!" + qpea[j])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qpea[j]);
                        break;
                    }
                }

                //Ragman
                string[] qrag = {"Only_business", "Make_Ultra_Great_Again", "Big_sale", "The_Blood_of_War_-_Part_1", "Dressed_to_kill", "Gratitude", "Sales_Night", "Hot_delivery", "Database_-_Part_1","Database_-_Part_2",
                        "Minibus", "Sew_it_good_-_Part_1", "Sew_it_good_-_Part_2", "Sew_it_good_-_Part_3", "Sew_it_good_-_Part_4", "he_Blood_of_War_-_Part_2", "he_Blood_of_War_-_Part_3", "The_key_to_success", "Living_high_is_not_a_crime_-_Part_1",
                        "Living_high_is_not_a_crime_-_Part_2", "Charisma_brings_success", "No_fuss_needed", "Supervisor", "Scavanger"};

                if (message.Content == "!qrag")
                {
                    await message.Channel.SendMessageAsync("```!Only_business\n!Make_Ultra_Great_Again\n!Big_sale\n!The_Blood_of_War_-_Part_1\n!Dressed_to_kill\n!Gratitude\n!Sales_Night\n!Hot_delivery\n!Database_-_Part_1\n!Database_-_Part_2\n" +
                        "!Minibus\n!Sew_it_good_-_Part_1\n!Sew_it_good_-_Part_2\n!Sew_it_good_-_Part_3\n!Sew_it_good_-_Part_4\n!The_Blood_of_War_-_Part_2\n!The_Blood_of_War_-_Part_3\n!The_key_to_success\n!Living_high_is_not_a_crime_-_Part_1\n" +
                        "!Living_high_is_not_a_crime_-_Part_2\n!Charisma_brings_success\n!No_fuss_needed\n!Supervisor\n!Scavanger```");
                }
                for (int i = 0; i < qrag.Length; i++)
                {
                    if (message.Content == "!" + qrag[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qrag[i]);
                        break;
                    }
                }

                //Jaeger
                string[] qjae = { "Acquaintance", "The_survivalist_path_-_Unprotected,_but_dangerous", "The_survivalist_path_-_Thrifty", "The_survivalist_path_-_Zhivchik", "The_survivalist_path_-_Wounded_beast", "The_survivalist_path_-_Tough_guy",
                        "The_survivalist_path_-_Cold_blooded", "The_survivalist_path_-_Zatoichi", "The_survivalist_path_-_Eagle-owl", "The_survivalist_path_-_Combat_medic", "Huntsman_path_-_Secured_perimeter", "Huntsman_path_-_The_trophy",
                        "Huntsman_path_-_Woods_cleaning", "Huntsman_path_-_Controller", "Huntsman_path_-_Sell-out", "Huntsman_path_-_Woods_keeper", "Huntsman_path_-_Justice", "Huntsman_path_-_Evil_watchman","Huntsman_path_-_Eraser","Huntsman_path_-_Eraser_-_Part_2",
                        "Ambulance", "Shady_business", "Nostalgia", "Fishing_place", "Countesy_visit", "Hunting_trip", "Reserv", "The_Tarkov_shooter_-_Part_1","The_Tarkov_shooter_-_Part_2","The_Tarkov_shooter_-_Part_3","The_Tarkov_shooter_-_Part_4",
                        "The_Tarkov_shooter_-_Part_5","The_Tarkov_shooter_-_Part_6","The_Tarkov_shooter_-_Part_7","The_Tarkov_shooter_-_Part_8" };

                if (message.Content == "!qjae")
                {
                    await message.Channel.SendMessageAsync("```!Acquaintance\n!The_survivalist_path_-_Unprotected,_but_dangerous\n!The_survivalist_path_-_Thrifty\n!The_survivalist_path_-_Zhivchik\n!The_survivalist_path_-_Wounded_beast\n!The_survivalist_path_-_Tough_guy\n" +
                        "!The_survivalist_path_-_Cold_blooded\n!The_survivalist_path_-_Zatoichi\n!The_survivalist_path_-_Eagle-owl\n!The_survivalist_path_-_Combat_medic\n!Huntsman_path_-_Secured_perimeter\n!Huntsman_path_-_The_trophy\n" +
                        "!Huntsman_path_-_Woods_cleaning\n!Huntsman_path_-_Controller\n!Huntsman_path_-_Sell-out\n!Huntsman_path_-_Woods_keeper\n!Huntsman_path_-_Justice\n!Huntsman_path_-_Evil_watchman\n!Huntsman_path_-_Eraser\n!Huntsman_path_-_Eraser_-_Part_2\n" +
                        "!Ambulance\n!Shady_business\n!Nostalgia\n!Fishing_place\n!Countesy_visit\n!Hunting_trip\n!Reserv\n!The_Tarkov_shooter_-_Part_1\n!The_Tarkov_shooter_-_Part_2\n!The_Tarkov_shooter_-_Part_3\n!The_Tarkov_shooter_-_Part_4\n" +
                        "!The_Tarkov_shooter_-_Part_5\n!The_Tarkov_shooter_-_Part_6\n!The_Tarkov_shooter_-_Part_7\n!The_Tarkov_shooter_-_Part_8```");
                }

                for (int i = 0; i < qjae.Length; i++)
                {
                    if (message.Content == "!" + qjae[i])
                    {
                        await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/" + qjae[i]);
                        break;
                    }
                }

                /////////////////////////////////사이트 특수문자 예외/////////////////////////////////////////////
                if (message.Content == "!What's_on_the_flash_drive?") //skier
                {
                    await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/What%27s_on_the_flash_drive%3F");
                }
                else if (message.Content == "!Vitamins_-_Part_1")      //skier
                {
                    await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/%22Vitamins%22_-_Part_1");
                }
                else if (message.Content == "!Vitamins_-_Part_2")      //skier
                {
                    await message.Channel.SendMessageAsync("https://escapefromtarkov.gamepedia.com/%22Vitamins%22_-_Part_2");
                }

            }

            if (message.Content == "!FREE LANGSKNE")
            {
                await message.Channel.SendMessageAsync("**해마TL:너밴.**");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

