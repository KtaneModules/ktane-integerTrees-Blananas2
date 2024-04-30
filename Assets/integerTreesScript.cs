﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class integerTreesScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;

    public TextMesh[] iTexts;
    public TextMesh oText;
    public KMSelectable[] uArrows;
    public KMSelectable rArrow;

    int p, q, ans = 1;
    int[] iNums = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 24, 25, 27, 28, 30, 32, 35, 36, 40, 42, 45, 48, 49, 50, 54, 56, 60, 63, 64, 70, 72, 75, 80, 81, 84, 90, 96, 98, 100, 105, 108, 112, 120, 125, 126, 128, 135, 140, 144, 147, 150, 160, 162, 168, 175, 180, 189, 192, 196, 200, 210, 216, 224, 225, 240, 243, 245, 250, 252, 256, 270, 280, 288, 294, 300, 315, 320, 324, 336, 343, 350, 360, 375, 378, 384, 392, 400, 405, 420, 432, 441, 448, 450, 480, 486, 490, 500, 504, 512, 525, 540, 560, 567, 576, 588, 600, 625, 630, 640, 648, 672, 675, 686, 700, 720, 729, 735, 750, 756, 768, 784, 800, 810, 840, 864, 875, 882, 896, 900, 945, 960, 972, 980, 1000, 1008, 1024, 1029, 1050, 1080, 1120, 1125, 1134, 1152, 1176, 1200, 1215, 1225, 1250, 1260, 1280, 1296, 1323, 1344, 1350, 1372, 1400, 1440, 1458, 1470, 1500, 1512, 1536, 1568, 1575, 1600, 1620, 1680, 1701, 1715, 1728, 1750, 1764, 1792, 1800, 1875, 1890, 1920, 1944, 1960, 2000, 2016, 2025, 2048, 2058, 2100, 2160, 2187, 2205, 2240, 2250, 2268, 2304, 2352, 2400, 2401, 2430, 2450, 2500, 2520, 2560, 2592, 2625, 2646, 2688, 2700, 2744, 2800, 2835, 2880, 2916, 2940, 3000, 3024, 3072, 3087, 3125, 3136, 3150, 3200, 3240, 3360, 3375, 3402, 3430, 3456, 3500, 3528, 3584, 3600, 3645, 3675, 3750, 3780, 3840, 3888, 3920, 3969, 4000, 4032, 4050, 4096, 4116, 4200, 4320, 4374, 4375, 4410, 4480, 4500, 4536, 4608, 4704, 4725, 4800, 4802, 4860, 4900, 5000, 5040, 5103, 5120, 5145, 5184, 5250, 5292, 5376, 5400, 5488, 5600, 5625, 5670, 5760, 5832, 5880, 6000, 6048, 6075, 6125, 6144, 6174, 6250, 6272, 6300, 6400, 6480, 6561, 6615, 6720, 6750, 6804, 6860, 6912, 7000, 7056, 7168, 7200, 7203, 7290, 7350, 7500, 7560, 7680, 7776, 7840, 7875, 7938, 8000, 8064, 8100, 8192, 8232, 8400, 8505, 8575, 8640, 8748, 8750, 8820, 8960, 9000, 9072, 9216, 9261, 9375, 9408, 9450, 9600, 9604, 9720, 9800, 10000, 10080, 10125, 10206, 10240, 10290, 10368, 10500, 10584, 10752, 10800, 10935, 10976, 11025, 11200, 11250, 11340, 11520, 11664, 11760, 11907, 12000, 12005, 12096, 12150, 12250, 12288, 12348, 12500, 12544, 12600, 12800, 12960, 13122, 13125, 13230, 13440, 13500, 13608, 13720, 13824, 14000, 14112, 14175, 14336, 14400, 14406, 14580, 14700, 15000, 15120, 15309, 15360, 15435, 15552, 15625, 15680, 15750, 15876, 16000, 16128, 16200, 16384, 16464, 16800, 16807, 16875, 17010, 17150, 17280, 17496, 17500, 17640, 17920, 18000, 18144, 18225, 18375, 18432, 18522, 18750, 18816, 18900, 19200, 19208, 19440, 19600, 19683, 19845, 20000, 20160, 20250, 20412, 20480, 20580, 20736, 21000, 21168, 21504, 21600, 21609, 21870, 21875, 21952, 22050, 22400, 22500, 22680, 23040, 23328, 23520, 23625, 23814, 24000, 24010, 24192, 24300, 24500, 24576, 24696, 25000, 25088, 25200, 25515, 25600, 25725, 25920, 26244, 26250, 26460, 26880, 27000, 27216, 27440, 27648, 27783, 28000, 28125, 28224, 28350, 28672, 28800, 28812, 29160, 29400, 30000, 30240, 30375, 30618, 30625, 30720, 30870, 31104, 31250, 31360, 31500, 31752, 32000, 32256, 32400, 32768, 32805, 32928, 33075, 33600, 33614, 33750, 34020, 34300, 34560, 34992, 35000, 35280, 35721, 35840, 36000, 36015, 36288, 36450, 36750, 36864, 37044, 37500, 37632, 37800, 38400, 38416, 38880, 39200, 39366, 39375, 39690, 40000, 40320, 40500, 40824, 40960, 41160, 41472, 42000, 42336, 42525, 42875, 43008, 43200, 43218, 43740, 43750, 43904, 44100, 44800, 45000, 45360, 45927, 46080, 46305, 46656, 46875, 47040, 47250, 47628, 48000, 48020, 48384, 48600, 49000, 49152, 49392, 50000, 50176, 50400, 50421, 50625, 51030, 51200, 51450, 51840, 52488, 52500, 52920, 53760, 54000, 54432, 54675, 54880, 55125, 55296, 55566, 56000, 56250, 56448, 56700, 57344, 57600, 57624, 58320, 58800, 59049, 59535, 60000, 60025, 60480, 60750, 61236, 61250, 61440, 61740, 62208, 62500, 62720, 63000, 63504, 64000, 64512, 64800, 64827, 65536, 65610, 65625, 65856, 66150, 67200, 67228, 67500, 68040, 68600, 69120, 69984, 70000, 70560, 70875, 71442, 71680, 72000, 72030, 72576, 72900, 73500, 73728, 74088, 75000, 75264, 75600, 76545, 76800, 76832, 77175, 77760, 78125, 78400, 78732, 78750, 79380, 80000, 80640, 81000, 81648, 81920, 82320, 82944, 83349, 84000, 84035, 84375, 84672, 85050, 85750, 86016, 86400, 86436, 87480, 87500, 87808, 88200, 89600, 90000, 90720, 91125, 91854, 91875, 92160, 92610, 93312, 93750, 94080, 94500, 95256, 96000, 96040, 96768, 97200, 98000, 98304, 98415, 98784, 99225, 100000, 100352, 100800, 100842, 101250, 102060, 102400, 102900, 103680, 104976, 105000, 105840, 107163, 107520, 108000, 108045, 108864, 109350, 109375, 109760, 110250, 110592, 111132, 112000, 112500, 112896, 113400, 114688, 115200, 115248, 116640, 117600, 117649, 118098, 118125, 119070, 120000, 120050, 120960, 121500, 122472, 122500, 122880, 123480, 124416, 125000, 125440, 126000, 127008, 127575, 128000, 128625, 129024, 129600, 129654, 131072, 131220, 131250, 131712, 132300, 134400, 134456, 135000, 136080, 137200, 137781, 138240, 138915, 139968, 140000, 140625, 141120, 141750, 142884, 143360, 144000, 144060, 145152, 145800, 147000, 147456, 148176, 150000, 150528, 151200, 151263, 151875, 153090, 153125, 153600, 153664, 154350, 155520, 156250, 156800, 157464, 157500, 158760, 160000, 161280, 162000, 163296, 163840, 164025, 164640, 165375, 165888, 166698, 168000, 168070, 168750, 169344, 170100, 171500, 172032, 172800, 172872, 174960, 175000, 175616, 176400, 177147, 178605, 179200, 180000, 180075, 181440, 182250, 183708, 183750, 184320, 185220, 186624, 187500, 188160, 189000, 190512, 192000, 192080, 193536, 194400, 194481, 196000, 196608, 196830, 196875, 197568, 198450, 200000, 200704, 201600, 201684, 202500, 204120, 204800, 205800, 207360, 209952, 210000, 211680, 212625, 214326, 214375, 215040, 216000, 216090, 217728, 218700, 218750, 219520, 220500, 221184, 222264, 224000, 225000, 225792, 226800, 229376, 229635, 230400, 230496, 231525, 233280, 234375, 235200, 235298, 236196, 236250, 238140, 240000, 240100, 241920, 243000, 244944, 245000, 245760, 246960, 248832, 250000, 250047, 250880, 252000, 252105, 253125, 254016, 255150, 256000, 257250, 258048, 259200, 259308, 262144, 262440, 262500, 263424, 264600, 268800, 268912, 270000, 272160, 273375, 274400, 275562, 275625, 276480, 277830, 279936, 280000, 281250, 282240, 283500, 285768, 286720, 288000, 288120, 290304, 291600, 294000, 294912, 295245, 296352, 297675, 300000, 300125, 301056, 302400, 302526, 303750, 306180, 306250, 307200, 307328, 308700, 311040, 312500, 313600, 314928, 315000, 317520, 320000, 321489, 322560, 324000, 324135, 326592, 327680, 328050, 328125, 329280, 330750, 331776, 333396, 336000, 336140, 337500, 338688, 340200, 343000, 344064, 345600, 345744, 349920, 350000, 351232, 352800, 352947, 354294, 354375, 357210, 358400, 360000, 360150, 362880, 364500, 367416, 367500, 368640, 370440, 373248, 375000, 376320, 378000, 381024, 382725, 384000, 384160, 385875, 387072, 388800, 388962, 390625, 392000, 393216, 393660, 393750, 395136, 396900, 400000, 401408, 403200, 403368, 405000, 408240, 409600, 411600, 413343, 414720, 416745, 419904, 420000, 420175, 421875, 423360, 425250, 428652, 428750, 430080, 432000, 432180, 435456, 437400, 437500, 439040, 441000, 442368, 444528, 448000, 450000, 451584, 453600, 453789, 455625, 458752, 459270, 459375, 460800, 460992, 463050, 466560, 468750, 470400, 470596, 472392, 472500, 476280, 480000, 480200, 483840, 486000, 489888, 490000, 491520, 492075, 493920, 496125, 497664, 500000, 500094, 501760, 504000, 504210, 506250, 508032, 510300, 512000, 514500, 516096, 518400, 518616, 524288, 524880, 525000, 526848, 529200, 531441, 535815, 537600, 537824, 540000, 540225, 544320, 546750, 546875, 548800, 551124, 551250, 552960, 555660, 559872, 560000, 562500, 564480, 567000, 571536, 573440, 576000, 576240, 580608, 583200, 583443, 588000, 588245, 589824, 590490, 590625, 592704, 595350, 600000, 600250, 602112, 604800, 605052, 607500, 612360, 612500, 614400, 614656, 617400, 622080, 625000, 627200, 629856, 630000, 635040, 637875, 640000, 642978, 643125, 645120, 648000, 648270, 653184, 655360, 656100, 656250, 658560, 661500, 663552, 666792, 672000, 672280, 675000, 677376, 680400, 686000, 688128, 688905, 691200, 691488, 694575, 699840, 700000, 702464, 703125, 705600, 705894, 708588, 708750, 714420, 716800, 720000, 720300, 725760, 729000, 734832, 735000, 737280, 740880, 746496, 750000, 750141, 752640, 756000, 756315, 759375, 762048, 765450, 765625, 768000, 768320, 771750, 774144, 777600, 777924, 781250, 784000, 786432, 787320, 787500, 790272, 793800, 800000, 802816, 806400, 806736, 810000, 816480, 819200, 820125, 823200, 823543, 826686, 826875, 829440, 833490, 839808, 840000, 840350, 843750, 846720, 850500, 857304, 857500, 860160, 864000, 864360, 870912, 874800, 875000, 878080, 882000, 884736, 885735, 889056, 893025, 896000, 900000, 900375, 903168, 907200, 907578, 911250, 917504, 918540, 918750, 921600, 921984, 926100, 933120, 937500, 940800, 941192, 944784, 945000, 952560, 960000, 960400, 964467, 967680, 972000, 972405, 979776, 980000, 983040, 984150, 984375, 987840, 992250, 995328, 1000000, 1000188, 1003520, 1008000, 1008420, 1012500, 1016064, 1020600, 1024000, 1029000, 1032192, 1036800, 1037232, 1048576, 1049760, 1050000, 1053696, 1058400, 1058841, 1062882, 1063125, 1071630, 1071875, 1075200, 1075648, 1080000, 1080450, 1088640, 1093500, 1093750, 1097600, 1102248, 1102500, 1105920, 1111320, 1119744, 1120000, 1125000, 1128960, 1134000, 1143072, 1146880, 1148175, 1152000, 1152480, 1157625, 1161216, 1166400, 1166886, 1171875, 1176000, 1176490, 1179648, 1180980, 1181250, 1185408, 1190700, 1200000, 1200500, 1204224, 1209600, 1210104, 1215000, 1224720, 1225000, 1228800, 1229312, 1234800, 1240029, 1244160, 1250000, 1250235, 1254400, 1259712, 1260000, 1260525, 1265625, 1270080, 1275750, 1280000, 1285956, 1286250, 1290240, 1296000, 1296540, 1306368, 1310720, 1312200, 1312500, 1317120, 1323000, 1327104, 1333584, 1344000, 1344560, 1350000, 1354752, 1360800, 1361367, 1366875, 1372000, 1376256, 1377810, 1378125, 1382400, 1382976, 1389150, 1399680, 1400000, 1404928, 1406250, 1411200, 1411788, 1417176, 1417500, 1428840, 1433600, 1440000, 1440600, 1451520, 1458000, 1469664, 1470000, 1474560, 1476225, 1481760, 1488375, 1492992, 1500000, 1500282, 1500625, 1505280, 1512000, 1512630, 1518750, 1524096, 1530900, 1531250, 1536000, 1536640, 1543500, 1548288, 1555200, 1555848, 1562500, 1568000, 1572864, 1574640, 1575000, 1580544, 1587600, 1594323, 1600000, 1605632, 1607445, 1612800, 1613472, 1620000, 1620675, 1632960, 1638400, 1640250, 1640625, 1646400, 1647086, 1653372, 1653750, 1658880, 1666980, 1679616, 1680000, 1680700, 1687500, 1693440, 1701000, 1714608, 1715000, 1720320, 1728000, 1728720, 1741824, 1749600, 1750000, 1750329, 1756160, 1764000, 1764735, 1769472, 1771470, 1771875, 1778112, 1786050, 1792000, 1800000, 1800750, 1806336, 1814400, 1815156, 1822500, 1835008, 1837080, 1837500, 1843200, 1843968, 1852200, 1866240, 1875000, 1881600, 1882384, 1889568, 1890000, 1905120, 1913625, 1920000, 1920800, 1928934, 1929375, 1935360, 1944000, 1944810, 1953125, 1959552, 1960000, 1966080, 1968300, 1968750, 1975680, 1984500, 1990656, 2000000, 2000376, 2007040, 2016000, 2016840, 2025000, 2032128, 2041200, 2048000, 2058000, 2064384, 2066715, 2073600, 2074464, 2083725, 2097152, 2099520, 2100000, 2100875, 2107392, 2109375, 2116800, 2117682, 2125764, 2126250, 2143260, 2143750, 2150400, 2151296, 2160000, 2160900, 2177280, 2187000, 2187500, 2195200, 2204496, 2205000, 2211840, 2222640, 2239488, 2240000, 2250000, 2250423, 2257920, 2268000, 2268945, 2278125, 2286144, 2293760, 2296350, 2296875, 2304000, 2304960, 2315250, 2322432, 2332800, 2333772, 2343750, 2352000, 2352980, 2359296, 2361960, 2362500, 2370816, 2381400, 2400000, 2401000, 2408448, 2419200, 2420208, 2430000, 2449440, 2450000, 2457600, 2458624, 2460375, 2469600, 2470629, 2480058, 2480625, 2488320, 2500000, 2500470, 2508800, 2519424, 2520000, 2521050, 2531250, 2540160, 2551500, 2560000, 2571912, 2572500, 2580480, 2592000, 2593080, 2612736, 2621440, 2624400, 2625000, 2634240, 2646000, 2654208, 2657205, 2667168, 2679075, 2688000, 2689120, 2700000, 2701125, 2709504, 2721600, 2722734, 2733750, 2734375, 2744000, 2752512, 2755620, 2756250, 2764800, 2765952, 2778300, 2799360, 2800000, 2809856, 2812500, 2822400, 2823576, 2834352, 2835000, 2857680, 2867200, 2880000, 2881200, 2893401, 2903040, 2916000, 2917215, 2939328, 2940000, 2941225, 2949120, 2952450, 2953125, 2963520, 2976750, 2985984, 3000000, 3000564, 3001250, 3010560, 3024000, 3025260, 3037500, 3048192, 3061800, 3062500, 3072000, 3073280, 3087000, 3096576, 3110400, 3111696, 3125000, 3136000, 3145728, 3149280, 3150000, 3161088, 3175200, 3176523, 3188646, 3189375, 3200000, 3211264, 3214890, 3215625, 3225600, 3226944, 3240000, 3241350, 3265920, 3276800, 3280500, 3281250, 3292800, 3294172, 3306744, 3307500, 3317760, 3333960, 3359232, 3360000, 3361400, 3375000, 3386880, 3402000, 3429216, 3430000, 3440640, 3444525, 3456000, 3457440, 3472875, 3483648, 3499200, 3500000, 3500658, 3512320, 3515625, 3528000, 3529470, 3538944, 3542940, 3543750, 3556224, 3572100, 3584000, 3600000, 3601500, 3612672, 3628800, 3630312, 3645000, 3670016, 3674160, 3675000, 3686400, 3687936, 3704400, 3720087, 3732480, 3750000, 3750705, 3763200, 3764768, 3779136, 3780000, 3781575, 3796875, 3810240, 3827250, 3828125, 3840000, 3841600, 3857868, 3858750, 3870720, 3888000, 3889620, 3906250, 3919104, 3920000, 3932160, 3936600, 3937500, 3951360, 3969000, 3981312, 4000000, 4000752, 4014080, 4032000, 4033680, 4050000, 4064256, 4082400, 4084101, 4096000, 4100625, 4116000, 4117715, 4128768, 4133430, 4134375, 4147200, 4148928, 4167450, 4194304, 4199040, 4200000, 4201750, 4214784, 4218750, 4233600, 4235364, 4251528, 4252500, 4286520, 4287500, 4300800, 4302592, 4320000, 4321800, 4354560, 4374000, 4375000, 4390400, 4408992, 4410000, 4423680, 4428675, 4445280, 4465125, 4478976, 4480000, 4500000, 4500846, 4501875, 4515840, 4536000, 4537890, 4556250, 4572288, 4587520, 4592700, 4593750, 4608000, 4609920, 4630500, 4644864, 4665600, 4667544, 4687500, 4704000, 4705960, 4718592, 4723920, 4725000, 4741632, 4762800, 4782969, 4800000, 4802000, 4816896, 4822335, 4838400, 4840416, 4860000, 4862025, 4898880, 4900000, 4915200, 4917248, 4920750, 4921875, 4939200, 4941258, 4960116, 4961250, 4976640, 5000000, 5000940, 5017600, 5038848, 5040000, 5042100, 5062500, 5080320, 5103000, 5120000, 5143824, 5145000, 5160960, 5184000, 5186160, 5225472, 5242880, 5248800, 5250000, 5250987, 5268480, 5292000, 5294205, 5308416, 5314410, 5315625, 5334336, 5358150, 5359375, 5376000, 5378240, 5400000, 5402250, 5419008, 5443200, 5445468, 5467500, 5468750, 5488000, 5505024, 5511240, 5512500, 5529600, 5531904, 5556600, 5598720, 5600000, 5619712, 5625000, 5644800, 5647152, 5668704, 5670000, 5715360, 5734400, 5740875, 5760000, 5762400, 5764801, 5786802, 5788125, 5806080, 5832000, 5834430, 5859375, 5878656, 5880000, 5882450, 5898240, 5904900, 5906250, 5927040, 5953500, 5971968, 6000000, 6001128, 6002500, 6021120, 6048000, 6050520, 6075000, 6096384, 6123600, 6125000, 6144000, 6146560, 6174000, 6193152, 6200145, 6220800, 6223392, 6250000, 6251175, 6272000, 6291456, 6298560, 6300000, 6302625, 6322176, 6328125, 6350400, 6353046, 6377292, 6378750, 6400000, 6422528, 6429780, 6431250, 6451200, 6453888, 6480000, 6482700, 6531840, 6553600, 6561000, 6562500, 6585600, 6588344, 6613488, 6615000, 6635520, 6667920, 6718464, 6720000, 6722800, 6750000, 6751269, 6773760, 6804000, 6806835, 6834375, 6858432, 6860000, 6881280, 6889050, 6890625, 6912000, 6914880, 6945750, 6967296, 6998400, 7000000, 7001316, 7024640, 7031250, 7056000, 7058940, 7077888, 7085880, 7087500, 7112448, 7144200, 7168000, 7200000, 7203000, 7225344, 7257600, 7260624, 7290000, 7340032, 7348320, 7350000, 7372800, 7375872, 7381125, 7408800, 7411887, 7440174, 7441875, 7464960, 7500000, 7501410, 7503125, 7526400, 7529536, 7558272, 7560000, 7563150, 7593750, 7620480, 7654500, 7656250, 7680000, 7683200, 7715736, 7717500, 7741440, 7776000, 7779240, 7812500, 7838208, 7840000, 7864320, 7873200, 7875000, 7902720, 7938000, 7962624, 7971615, 8000000, 8001504, 8028160, 8037225, 8064000, 8067360, 8100000, 8103375, 8128512, 8164800, 8168202, 8192000, 8201250, 8203125, 8232000, 8235430, 8257536, 8266860, 8268750, 8294400, 8297856, 8334900, 8388608, 8398080, 8400000, 8403500, 8429568, 8437500, 8467200, 8470728, 8503056, 8505000, 8573040, 8575000, 8601600, 8605184, 8640000, 8643600, 8680203, 8709120, 8748000, 8750000, 8751645, 8780800, 8817984, 8820000, 8823675, 8847360, 8857350, 8859375, 8890560, 8930250, 8957952, 8960000, 9000000, 9001692, 9003750, 9031680, 9072000, 9075780, 9112500, 9144576, 9175040, 9185400, 9187500, 9216000, 9219840, 9261000, 9289728, 9331200, 9335088, 9375000, 9408000, 9411920, 9437184, 9447840, 9450000, 9483264, 9525600, 9529569, 9565938, 9568125, 9600000, 9604000, 9633792, 9644670, 9646875, 9676800, 9680832, 9720000, 9724050, 9765625, 9797760, 9800000, 9830400, 9834496, 9841500, 9843750, 9878400, 9882516, 9920232, 9922500, 9953280 };
    int[][] tfRows = { new int[] { 0, 1, 2 }, new int[] { 0, 1, 3 }, new int[] { 0, 1, 4 }, new int[] { 0, 1, 5 }, new int[] { 0, 1, 6 }, new int[] { 0, 1, 7 }, new int[] { 0, 2, 3 }, new int[] { 0, 3, 4 }, new int[] { 0, 4, 5 }, new int[] { 0, 5, 6 }, new int[] { 0, 6, 7 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 5 }, new int[] { 1, 2, 6 }, new int[] { 1, 2, 7 }, new int[] { 1, 3, 4 }, new int[] { 1, 4, 5 }, new int[] { 1, 5, 6 }, new int[] { 1, 6, 7 }, new int[] { 2, 3, 4 }, new int[] { 2, 3, 5 }, new int[] { 2, 3, 6 }, new int[] { 2, 3, 7 }, new int[] { 2, 4, 5 }, new int[] { 2, 5, 6 }, new int[] { 2, 6, 7 }, new int[] { 3, 4, 5 }, new int[] { 3, 4, 6 }, new int[] { 3, 4, 7 }, new int[] { 3, 5, 6 }, new int[] { 3, 6, 7 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 7 }, new int[] { 4, 6, 7 }, new int[] { 5, 6, 7 } };
    int[] pTree, qTree;
    int[] aDigits = { 0, 0, 0, 0, 0, 0, 0, 0 };

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable arw in uArrows) {
            arw.OnInteract += delegate () { UpArrowPress(arw); return false; };
        }

        rArrow.OnInteract += delegate () { Submit(); return false; };
    }

    void Start () {
        GeneratePuzzle();
    }

    void GeneratePuzzle() {
        tryAgain:
        p = iNums.PickRandom();
        do {
            q = iNums.PickRandom();
        } while (p == q);
        pTree = Tree(p, Bomb.GetSerialNumber()[0]);
        qTree = Tree(q, Bomb.GetSerialNumber()[1]);

        int noPosCount = 0;
        int[] aTree = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int x = 0; x < 15; x++) {
            if (pTree[x] == 0 && qTree[x] == 0) {
                noPosCount++;
            } else {
                int prod = Math.Abs(pTree[x] - qTree[x]);
                aTree[x] = prod;
                if (prod != 0) {
                    ans *= prod;
                }
            }
        }
        ans *= noPosCount;
        if (ans > 99999999) {
            Debug.LogFormat("<Integer Trees #{0}> This pair exceeded the limit: {1}, {2}", moduleId, p, q);
            goto tryAgain;
        }

        iTexts[0].text = p.ToString("0000000");
        iTexts[1].text = q.ToString("0000000");

        Debug.LogFormat("[Integer Trees #{0}] Given input integers are {1} and {2}", moduleId, p, q);
        Debug.LogFormat("[Integer Trees #{0}] Tree for p: {1}", moduleId, LogTree(pTree));
        Debug.LogFormat("[Integer Trees #{0}] Tree for q: {1}", moduleId, LogTree(qTree));
        Debug.LogFormat("[Integer Trees #{0}] Answer tree: {1}", moduleId, LogTree(aTree));
        Debug.LogFormat("[Integer Trees #{0}] The product of the answer tree is {1}", moduleId, ans/noPosCount);
        Debug.LogFormat("[Integer Trees #{0}] There are {1} positions with a digit in neither input trees", moduleId, noPosCount);
        Debug.LogFormat("[Integer Trees #{0}] The answer is {1}", moduleId, ans);
    }

    int[] Tree(int j, char c) {
        string b36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int tIx = b36.IndexOf(c);
        int[] finalRow = tfRows[tIx];

        int[] tree = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int treePos = 0;
        int k = j;
        int n = 9;

        while (treePos < 10) {
            if (k % n == 0) {
                k = k / n;
                if (treePos < 7) {
                    tree[treePos] = n;
                } else {
                    tree[7 + finalRow[treePos - 7]] = n;
                }
                treePos++;
            } else {
                n--;
            }
        }

        return tree;
    }

    string LogTree(int[] t) {
        string s = "";
        for (int e = 0; e < t.Count(); e++) {
            s += (t[e] == 0) ? "x" : t[e].ToString();
            switch (e) {
                case 0: case 2: case 6: s += " / "; break;
                case 14: /* nothing */ break;
                default: s += ","; break;
            }
        }
        return s;
    }

    void UpArrowPress(KMSelectable arw) {
        arw.AddInteractionPunch(0.5f);
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, arw.transform);
        for (int a = 0; a < 8; a++) {
            if (arw == uArrows[a]) {
                aDigits[a] = (aDigits[a] + 1)%10;
                oText.text = aDigits.Join("");
            }
        }
    }

    void Submit() {
        rArrow.AddInteractionPunch();
        if (moduleSolved) { return; }
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, rArrow.transform);
        if (ans.ToString("00000000") == oText.text) {
            moduleSolved = true;
            Debug.LogFormat("[Integer Trees #{0}] Correct answer given. Module solved.", moduleId);
            GetComponent<KMBombModule>().HandlePass();
        } else {
            string wrong = oText.text.TrimStart('0');
            Debug.LogFormat("[Integer Trees #{0}] Incorrect answer ({1}) given, strike!", moduleId, (wrong.Length == 0) ? "0" : wrong);
            GetComponent<KMBombModule>().HandleStrike();
        }
    }

    //twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} submit <answer> [Submits an answer]";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        string[] parameters = command.Split(' ');
        if (parameters[0].EqualsIgnoreCase("submit"))
        {
            if (parameters.Length > 2)
                yield return "sendtochaterror Too many parameters!";
            else if (parameters.Length == 2)
            {
                int temp;
                if (!int.TryParse(parameters[1], out temp))
                {
                    yield return "sendtochaterror The specified answer '" + parameters[1] + "' is invalid!";
                    yield break;
                }
                if (temp < 0 || temp > 99999999)
                {
                    yield return "sendtochaterror The specified answer '" + parameters[1] + "' is invalid!";
                    yield break;
                }
                yield return null;
                string submission = temp.ToString("00000000");
                for (int i = 0; i < submission.Length; i++)
                {
                    while (oText.text[i] != submission[i])
                    {
                        uArrows[i].OnInteract();
                        yield return new WaitForSeconds(.1f);
                    }
                }
                rArrow.OnInteract();
            }
            else
                yield return "sendtochaterror Please specify an answer to submit!";
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        string answer = ans.ToString("00000000");
        for (int i = 0; i < answer.Length; i++)
        {
            while (oText.text[i] != answer[i])
            {
                uArrows[i].OnInteract();
                yield return new WaitForSeconds(.1f);
            }
        }
        rArrow.OnInteract();
    }
}