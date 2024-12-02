using System.Text;
using url_shortener.infrastructure.RandomStringGenerators.Interfaces;

namespace url_shortener.infrastructure.RandomStringGenerators;

public class ThreeWordPhraseGenerator : IRandomStringGenerator
{
    private readonly Random random = new();

    public string Generate()
    {
        StringBuilder sb = new();
        bool second = false;
        for (int i = 0; i < 3; i++) {
            int randomIndex = random.Next(THREE_LETTER_WORDS.Length - 1);
            if (second)
                sb.Append("-");
            sb.Append(THREE_LETTER_WORDS[randomIndex]);
            second = true;
        }
        return sb.ToString();
    }
    
    static string[] THREE_LETTER_WORDS = {
"Aani","Aaru","abac","abas","Abba","Abby","abed","Abel","abet","abey","Abie","abir","able","ably","abox"
,"Absi","abut","acca","Acer","ache","achy","acid","Acis","acle","acme","acne","acor","acre","acta","Acts"
,"actu","acyl","Adad","adad","Adai","Adam","Adar","adat","adaw","aday","Adda","adda","Addu","Addy","adet"
,"Adib","Adin","adit","admi","adry","adze","aeon","aero","aery","Afar","afar","affa","affy","Agag","agal"
,"Agao","agar","Agau","Agaz","aged","agee","agen","ager","agha","Agib","agio","agla","agog","agon","Agra"
,"agre","agua","ague","ahem","Ahet","ahey","Ahir","Ahom","ahoy","ahum","Aias","aide","aiel","aile","aint"
,"Ainu","aion","Aira","aire","airt","airy","ajar","ajog","Akal","Akan","akee","akey","Akha","akia","Akim"
,"akin","Akka","akov","Akra","akra","Alan","alan","alar","alas","alba","albe","Albi","Alca","alco","Alea"
,"alec","alee","alef","alem","alen","Alex","alfa","alga","Algy","alif","alin","alit","Alix","alky","Alle"
,"Ally","ally","Alma","alma","alme","alms","alod","aloe","alop","alow","also","alto","alum","Alur","Alya"
,"amah","amar","amba","ambo","Amen","amen","Amex","Amia","amic","amid","amil","amin","Amir","amir","amla"
,"amli","Amma","amma","Ammi","ammo","ammu","amok","amor","Amos","Amoy","amra","amyl","anal","Anam","anam"
,"anan","Anas","Anat","Anax","anay","anba","anda","Ande","Andi","Andy","anes","anew","ango","anil","anis"
,"ankh","Anna","anna","Anne","anoa","anon","ansa","ansu","Anta","anta","ante","Anti","anti","Antu","antu"
,"anus","Aoul","apar","aper","apex","apii","apio","Apis","apod","apse","Apus","aqua","aquo","Arab","arad"
,"arar","arba","arca","arch","ardu","area","ared","Argo","argo","aria","arid","aril","arms","army","arna"
,"Arne","arni","arow","Arry","arse","arty","arui","Arum","Arya","aryl","asak","asci","asem","Asha","ashy"
,"Askr","asok","asop","asor","asse","assi","asta","atap","atef","Aten","ates","Atik","atip","atis","Atka"
,"atle","atma","atmo","atom","atop","atry","Atta","atta","atwo","aube","Auca","auca","auge","augh","aula"
,"auld","aulu","aune","aunt","aura","ausu","aute","auto","aval","Avar","aver","Aves","avid","Avis","avow"
,"awag","Awan","awat","away","awee","awfu","awin","awny","Awol","awry","axal","axed","Axel","axes","axil"
,"Axis","axis","axle","axon","ayah","ayin","Azha","azon","azox","Baal","baal","baar","baba","babe","Babi"
,"Babs","babu","baby","bach","back","bade","baff","baft","baga","bago","baho","baht","bail","bain","Bais"
,"bait","baka","bake","Baku","baku","Bala","bald","bale","Bali","bali","balk","ball","balm","Balt","balu"
,"Bana","banc","band","bane","bang","bani","bank","bant","bara","barb","bard","Bare","bare","Bari","bari"
,"bark","barm","barn","Bart","baru","base","bash","bask","bass","Bast","bast","bate","Bath","bath","bats"
,"batt","batz","baud","baul","baun","bawd","bawl","bawn","Baya","baya","baze","bead","beak","beal","beam"
,"bean","bear","beat","beau","Beck","beck","beef","beek","been","beer","bees","beet","bego","behn","Beid"
,"Beja","bela","beld","bell","belt","bely","bema","bena","bend","bene","beng","Beni","beni","benj","benn"
,"beno","bent","Benu","bere","berg","Beri","berm","Bern","Bert","besa","Bess","best","Beta","beta","Beth"
,"beth","bevy","Bhar","bhat","Bhil","bhoy","bhut","bias","bibb","bibi","Bice","bice","bick","bide","bien"
,"bier","biff","biga","bigg","bija","bike","bikh","bile","bilk","Bill","bill","bilo","bind","bine","bing"
,"binh","Bini","bink","bino","bint","biod","bion","bios","bird","biri","birk","birl","birn","birr","bite"
,"biti","bito","bitt","biwa","Bixa","bizz","blab","blad","blae","blah","blan","blas","blat","blaw","blay"
,"bleb","bled","blee","bleo","blet","blip","blob","bloc","blot","blow","blub","blue","blup","blur","boar"
,"boat","boba","bobo","boce","bock","bode","Bodo","body","Boer","boga","Bogo","bogo","bogy","boho","boid"
,"Boii","boil","Bois","bojo","boke","bola","bold","bole","bolk","boll","Bolo","bolo","bolt","boma","bomb"
,"bond","bone","bong","Boni","bonk","bony","boob","bood","boof","book","bool","boom","boon","boor","boot"
,"bora","bord","bore","borg","borh","born","Boro","boro","bort","Bosc","bose","bosh","bosk","bosn","boss"
,"bota","bote","both","bott","boud","bouk","boun","bout","bouw","bowk","bowl","boxy","Boyd","boza","bozo"
,"brab","Brad","brad","brae","brag","Bram","bran","brat","braw","bray","bred","bree","brei","Bret","bret"
,"brew","brey","brig","brim","brin","brit","brob","brod","brog","broo","brot","brow","brut","bual","buba"
,"Bube","Bubo","bubo","buck","buda","Budh","buff","bufo","Bugi","buhl","buhr","bukh","bulb","bulk","bull"
,"bult","bump","Buna","buna","bund","bung","bunk","bunt","buoy","burd","bure","burg","Buri","buri","burl"
,"burn","buro","burp","burr","burt","bury","bush","busk","buss","bust","busy","Bute","butt","buzz","byee"
,"bygo","byon","byre","byth","caam","caba","Caca","cack","cade","cadi","cafh","cage","Cagn","caid","Cain"
,"cain","cake","caky","calf","calk","call","calm","calp","calx","camb","Came","came","camp","Cana","cand"
,"cane","cank","cant","cany","Cape","cape","Caph","caph","Cara","card","care","cark","Carl","carl","Caro"
,"carp","carr","cart","Cary","Case","case","cash","cask","cass","cast","cate","cauk","caul","caum","caup"
,"cava","cave","cavy","cawk","caza","cede","ceil","cell","Celt","celt","cent","cepa","cepe","ceps","cere"
,"cern","cero","cess","cest","Cete","ceti","Ceyx","chaa","chab","Chac","chad","chai","chal","Cham","cham"
,"chao","chap","char","chat","chaw","chay","chee","chef","Chen","Chet","chew","chia","chic","chid","chih"
,"chil","Chin","chin","Chip","chip","chit","chob","Chol","chol","chop","Chou","chow","chub","Chud","chug"
,"chum","Chun","chun","chut","cine","cion","cipo","cise","cist","cite","city","cive","Cixo","clad","clag"
,"clam","clan","clap","clat","claw","Clay","clay","cled","clee","clef","cleg","Clem","clem","clep","clew"
,"Clio","clip","clit","clod","clog","clop","clot","clow","cloy","club","clue","coak","coal","Coan","coat"
,"coax","coca","cock","coco","coda","code","codo","coed","coff","coft","coho","coif","coil","coin","coir"
,"Coix","coke","coky","Cola","cola","cold","Cole","cole","coli","colk","coll","colp","Colt","colt","coly"
,"coma","comb","come","cond","cone","conk","conn","cony","coof","cook","cool","coom","coon","coop","Coos"
,"coot","copa","cope","copr","Copt","copy","Cora","cora","cord","core","corf","cork","corm","corn","corp"
,"Cory","cosh","coss","cost","cosy","cote","coth","coto","coue","coul","coup","cove","cowl","cowy","coxa"
,"coxy","coyo","coze","cozy","crab","crag","cram","cran","crap","craw","Crax","crea","Cree","cree","crew"
,"Crex","crib","cric","crig","crin","Cris","croc","Crom","crop","crow","croy","crum","crus","crux","Cuba"
,"cube","cubi","cuck","cuff","cuir","cuke","cull","culm","cult","cump","Cuna","Cuon","curb","curd","cure"
,"curl","curn","curr","Curt","curt","cush","cusk","cusp","cuss","cute","cuvy","cuya","cyan","cyke","cyma"
,"cyme","cyst","czar","dabb","dace","Dada","dada","dade","dado","Dadu","daer","daff","daft","Dago","dags"
,"Dail","dain","dais","Dale","dale","dali","dalk","dalt","dama","dame","damn","damp","Dana","dand","Dane"
,"dang","Dani","dank","Dard","dare","darg","dari","dark","darn","darr","dart","dash","dasi","data","date"
,"daub","daud","Daur","daut","dauw","Dave","Davy","davy","Dawn","dawn","days","Daza","daze","dazy","dead"
,"deaf","deal","Dean","dean","dear","Debi","debt","deck","dedo","deed","deem","deep","deer","deft","defy"
,"degu","dele","delf","dell","deme","demi","demy","Dene","dene","dent","deny","depa","dere","derm","dern"
,"desi","desk","dess","deul","deva","dewy","dhai","dhak","dhan","dhaw","dhow","dial","Dian","dian","Diau"
,"dibs","dice","dich","Dick","dick","Dido","dieb","diem","dier","diet","digs","dika","Dike","dike","dill"
,"dilo","dime","dine","ding","dink","dint","diol","Dion","dird","dire","Dirk","dirk","dirl","dirt","Disa"
,"disc","dish","disk","diss","dita","dite","diva","dive","dixy","doab","doat","dobe","doby","dock","dodd"
,"Dode","dodo","Doeg","doer","does","doff","doge","dogs","dogy","doit","doke","Doko","dola","dole","doli"
,"doll","dolt","dome","domn","domy","done","dong","Donn","dont","doob","dook","dool","doom","doon","door"
,"dopa","dope","Dora","Dori","dorm","dorn","dorp","Dory","dory","dosa","dose","doss","dote","Doto","doty"
,"douc","Doug","doum","doup","dour","dout","dove","dowd","dowf","dowl","down","dowp","doxa","doxy","doze"
,"dozy","drab","drag","dram","drat","draw","dray","dree","dreg","Drew","drew","drib","drip","drop","drow"
,"drub","drug","drum","duad","dual","dubb","dubs","duck","Duco","duct","dude","duel","duer","duet","duff"
,"Duhr","duim","Duit","duit","Duke","duke","dull","dult","duly","duma","dumb","dump","dune","dung","dunk"
,"Duns","dunt","duny","dupe","dura","dure","durn","duro","dush","dusk","dust","duty","dyad","Dyak","Dyas"
,"dyce","dyer","dyke","dyne","each","Earl","earl","earn","ease","east","easy","eats","eave","Eben","Eboe"
,"eboe","ebon","ecad","Ecca","eche","echo","ecru","Edda","eddo","Eddy","eddy","edea","Eden","edge","edgy"
,"edit","Edna","eely","Efik","egad","Egba","Egbo","eggy","egma","egol","eheu","Ejam","ejoo","eker","ekka"
,"Ekoi","Elia","Ella","elle","elmy","elod","Elon","Elsa","else","Emil","Emim","emir","emit","Emma","emma"
,"empt","emyd","Emys","enam","Enid","Enif","Enki","enol","Enos","enow","ense","envy","eoan","epee","epha"
,"epic","epos","Eppy","eral","eria","Eric","eric","Erie","Erik","Erma","erne","Eros","eros","Erse","erth"
,"eruc","Eryx","esca","esne","Esox","espy","Esth","etch","etna","Etta","etua","etui","etym","euge","Evan"
,"Evea","even","ever","evil","evoe","ewer","ewry","exam","exes","exit","Exon","exon","eyah","eyas","eyed"
,"eyen","eyer","eyey","eyne","eyot","eyra","eyre","ezba","Ezra","Faba","face","fack","fact","facy","fade"
,"fady","faff","fage","fail","fain","fair","fake","faky","fall","falx","Fama","fame","fana","fand","fang"
,"fant","Fany","faon","fare","farl","farm","faro","fash","fass","fast","fate","faun","favn","fawn","faze"
,"feak","feal","fear","feat","feck","feed","feel","feer","feif","feil","feis","fell","fels","felt","Feme"
,"feme","fend","fent","feod","ferk","fern","feru","fess","fest","feud","fiar","fiat","fice","fico","fide"
,"Fido","Fife","fife","fifo","Fiji","fike","file","fill","film","filo","fils","find","fine","fink","Finn"
,"Fiot","fire","firk","firm","firn","fisc","fise","fish","fist","five","fizz","flag","flak","flam","flan"
,"flap","flat","flaw","flax","flay","flea","fled","flee","Flem","flet","flew","flex","fley","flip","flit"
,"flix","flob","floc","floe","flog","flop","flot","flow","flub","flue","flux","foal","foam","foci","fogo"
,"fogy","foil","fold","fole","folk","fond","fono","fons","font","food","fool","foot","fora","forb","ford"
,"fore","fork","form","fort","fosh","foud","foul","foun","four","fowk","fowl","foxy","fozy","frab","frae"
,"Fram","frap","frat","fray","Fred","free","fret","frib","frig","frim","frit","friz","froe","frog","from"
,"frot","frow","fuci","fuel","fuff","fugu","fuji","fulk","full","fume","fumy","fund","funk","funt","furl"
,"fury","fusc","fuse","fuss","fust","fute","fuye","fuze","fuzz","fyke","fyrd","Gabe","gabi","gaby","gade"
,"Gael","gaen","gaet","gaff","gage","Gaia","Gail","gain","gair","gait","gala","Gale","gale","gali","gall"
,"galp","galt","gamb","game","gamp","gamy","gane","gang","gant","gaol","Gaon","Gapa","gapa","gape","gapo"
,"gapy","gara","garb","gare","garn","Garo","Gary","gash","gasp","gast","gata","gate","gaub","gaud","Gaul"
,"gaum","gaun","gaup","gaur","gaus","gaut","gave","gawk","gawm","gawn","gaze","gazi","gazy","geal","gean"
,"gear","Geat","geat","geck","geek","geet","Geez","gegg","gein","geld","gell","gelt","gena","Gene","gene"
,"gens","gent","genu","Geon","gerb","germ","gers","gest","geta","Geum","geum","Ghan","ghat","ghee","Gheg"
,"Ghuz","gibe","gied","gien","gift","Gigi","Gila","gild","Gill","gill","gilo","gilt","gimp","ging","gink"
,"gird","girl","girn","giro","girr","girt","gish","gist","gith","give","gizz","glad","glam","glar","glee"
,"gleg","Glen","glen","glia","glib","Glis","glom","glop","glor","glow","gloy","glub","glue","glug","glum"
,"glut","gnar","gnat","gnaw","goad","goaf","goal","Goan","goat","gobi","gobo","goby","gode","goel","goer"
,"goes","goff","Gogo","gogo","gola","Gold","gold","golf","goli","Goll","Golo","Goma","Gona","Gond","gone"
,"gong","gony","good","goof","gook","gool","goon","Goop","gora","gorb","gore","gory","gosh","gote","Goth"
,"goup","gout","gove","gowf","gowk","gowl","gown","grab","grad","gram","grat","gray","gree","Greg","grew"
,"grey","grid","grig","grim","grin","grip","gris","grit","grog","gros","grot","grow","grub","grue","grum"
,"grun","Grus","guan","guao","guar","gude","gufa","guff","gugu","Guha","guhr","guib","gula","gule","Gulf"
,"gulf","gull","Gulo","gulp","gump","guna","gunj","gunk","gunl","Gunz","gurk","gurl","gurr","gurt","guru"
,"gush","guss","gust","Guti","gutt","guze","gwag","Gwen","gyle","gyne","gype","Gyps","gyps","gyre","gyri"
,"gyro","gyte","gyve","haab","haaf","Habe","habu","hack","hade","hadj","haec","haem","haet","haff","haft"
,"hagi","haik","hail","hain","hair","haje","hake","hako","haku","hala","hale","half","hall","halo","hals"
,"halt","hame","hami","hand","Hank","hank","Hano","Hans","hant","Hapi","hapu","Harb","hard","hare","hark"
,"harl","harm","harn","harp","harr","hart","Harv","hash","hask","hasp","hate","hath","Hati","hatt","haul"
,"have","hawk","hawm","haya","hayz","haze","hazy","head","heaf","heal","heap","hear","heat","hech","heck"
,"heed","heel","heer","heft","Hehe","heii","Hein","heir","hele","hell","helm","help","heme","heml","hemp"
,"hend","hent","Herb","herb","herd","here","herl","hern","hero","hers","hest","hevi","hewn","hewt","hexa"
,"hick","hide","high","hike","hill","hilt","Hima","himp","hind","hing","hint","hipe","hire","hiro","hish"
,"hisn","hiss","hist","hive","hizz","Hler","hoar","hoax","hobo","hock","hoer","hoga","Hohe","Hohn","hoin"
,"hoit","hoju","hold","hole","holl","holm","holt","holy","home","homo","homy","hone","hong","honk","hood"
,"hoof","hook","hoon","hoop","hoot","hope","Hopi","hopi","hora","horn","hory","hose","host","hoti","hour"
,"Hova","hove","howe","howk","howl","Hoya","hubb","huck","hued","huer","Huey","huff","huge","Hugh","Hugo"
,"huia","huke","hula","hulk","hull","hulu","Huma","Hume","hump","hung","hunh","hunk","hunt","Hupa","Hura"
,"hura","hure","Hurf","hurl","hurr","hurt","huse","hush","husk","huso","huss","huzz","hyke","Hyla","hyle"
,"hymn","hyne","hypo","iamb","Ibad","Iban","ibex","ibid","ibis","iced","icho","ichu","icon","idea","ides"
,"idic","idle","idly","idol","idyl","iffy","iiwi","ijma","ikat","ikey","ikra","ilex","ilia","ilka","illy"
,"ilot","Ilya","imam","imbe","Imer","immi","impi","impy","inbe","inby","Inca","inch","inde","indy","Inez"
,"Inga","Inia","inks","inky","inly","inro","into","iodo","Ione","Ioni","iota","Iowa","ipid","ipil","Iran"
,"Iraq","irid","iris","Irma","irok","iron","isba","Isis","isle","ismy","itch","Itea","item","Iten","iter"
,"itmo","Itys","Itza","Ivan","ivin","iwis","Ixia","Ixil","Izar","izar","izle","Izzy","Jack","jack","jacu"
,"jade","jady","Jaga","jail","Jain","Jake","jake","jako","jama","jamb","jami","Jane","jane","jank","jann"
,"jaob","jape","jara","jarg","Jarl","jarl","jass","jati","jato","jauk","jaun","jaup","Java","jawy","jazz"
,"Jean","jean","jeel","jeep","jeer","Jeff","jeff","jehu","jell","jerk","jerl","jerm","jert","Jess","jess"
,"jest","Jesu","jete","Jewy","jhow","jibe","jibi","jiff","Jill","jilt","jimp","jina","jing","jink","jinn"
,"jinx","Jiri","jiti","jiva","jive","Joan","jobo","joch","Jock","jock","jocu","Jodo","Joel","Joey","joey"
,"John","join","joke","joky","joll","jolt","Jong","Joni","joom","Joon","Jose","Josh","josh","joss","jota"
,"joug","jouk","Jova","Jove","jowl","Jozy","Juan","juba","jube","juck","Jude","judo","Judy","Juga","Juha"
,"juju","juke","Jule","July","jump","June","june","junk","Juno","junt","jupe","Jura","jure","Juri","jury"
,"just","Jute","jute","Juza","Jynx","jynx","Kadu","Kafa","kago","kagu","kaha","kahu","kaid","kaik","kail"
,"kaka","kaki","kala","kale","kali","kalo","kame","kana","kang","kans","kapa","kapp","Kari","Karl","karo"
,"kasa","kasm","Kate","kath","Katy","kava","Kavi","kayo","kazi","keck","keek","keel","keen","keep","Kees"
,"keet","Keid","keld","Kele","kele","kelk","kell","kelp","kelt","kemb","kemp","kend","Kenn","keno","Kent"
,"kent","kepi","kept","kerf","kern","keta","keto","Ketu","keup","kexy","khan","khar","khat","khet","khir"
,"khot","kibe","kiby","kick","Kids","kiel","kier","Kiho","kike","Kiki","kiki","kiku","kill","kiln","kilo"
,"kilp","kilt","kina","kind","King","king","kink","kino","kipe","kiri","Kirk","kirk","kirn","kish","kiss"
,"kist","kite","kith","kiva","kivu","kiwi","kiyi","klam","Klan","klip","klom","klop","kmet","knab","knag"
,"knap","knar","knee","knet","knew","knez","knit","knob","knop","knot","know","knub","knur","Knut","knut"
,"koae","kobi","kobu","Koch","koda","koel","koff","koft","Kohl","kohl","koil","Koko","koko","koku","kola"
,"Koli","kolo","Kome","Komi","kona","koph","kopi","Kora","kora","Kore","kore","kori","Kory","Koso","Kota"
,"koto","kozo","Krag","kral","kran","kras","Kris","Kroo","Kuan","kuan","Kuar","Kuba","kuba","kudu","kuei"
,"kuge","Kuki","kuku","kula","Kuli","kulm","kung","kunk","Kurd","Kuri","Kurt","kusa","kwan","kyah","kyar"
,"kyat","Kyle","kyle","Kylo","kyte","lace","lack","lacy","lade","lady","laet","laic","laid","lain","lair"
,"lake","laky","lall","lalo","lama","lamb","lame","lamp","Lana","land","lane","lank","lant","lanx","Lapp"
,"lard","Lari","lari","lark","Lars","lasa","lash","Lasi","lask","lass","last","lata","late","lath","laud"
,"laun","laur","lava","lave","lawk","lawn","laze","lazy","Lead","lead","leaf","Leah","leak","leal","leam"
,"lean","leap","Lear","lear","leat","lech","leck","Leda","lede","leed","leek","leep","leer","lees","leet"
,"left","Lehi","lehr","Leif","Lena","lend","lene","leno","lens","Lent","lent","Leon","lepa","lerp","less"
,"lest","lete","Leto","Lett","leud","leuk","Levi","levo","levy","lewd","liar","Lias","lice","lich","lick"
,"Lida","Lide","lido","lied","lief","lien","lier","lieu","life","lifo","lift","liin","lija","like","Lila"
,"lile","lill","lilt","lily","Lima","limb","lime","limn","limo","limp","limu","limy","Lina","lina","line"
,"ling","link","linn","lino","lint","liny","lion","lipa","lira","lire","Lisa","Lise","lish","lisk","lisp"
,"liss","List","list","lite","lith","litz","live","Liza","Lleu","Llew","llyn","load","loaf","loam","loan"
,"lobe","lobo","loca","loch","loci","lock","loco","lode","loft","loge","logo","logy","loin","loir","Lois"
,"loka","loke","Lola","loll","Lolo","loma","lone","long","Lonk","lood","loof","look","loom","loon","loop"
,"loot","lope","Lora","lora","Lord","lord","lore","Lori","lori","lorn","loro","lors","lory","lose","losh"
,"loss","lost","Lota","lota","lote","lots","loud","louk","Loup","loup","lour","lout","love","lowa","lown"
,"lowy","Loyd","Luba","lube","luce","luck","Lucy","lucy","ludo","lues","luff","luge","Luis","Luke","luke"
,"Lula","lull","Lulu","lulu","lump","luna","lune","lung","lunn","lunt","lupe","lura","lure","lurg","Luri"
,"lurk","lush","lusk","lust","lute","luxe","lyam","Lyas","Lynn","lynx","Lyon","lyra","lyre","lyse","maam"
,"Maba","mabi","mace","mack","maco","made","Madi","mado","Maga","mage","Magh","Magi","magi","maha","Mahi"
,"Maia","maid","mail","maim","main","Maja","majo","make","maki","mako","Maku","mala","Male","male","mali"
,"mall","malm","malo","malt","mamo","mana","mand","mane","mang","mani","mank","Mann","mano","Mans","mant"
,"Manx","many","mapo","Mara","Marc","marc","mare","Mari","Mark","mark","marl","marm","maro","Mars","Mart"
,"mart","maru","Mary","mary","masa","mash","mask","Mass","mass","mast","masu","mate","math","Mats","Matt"
,"maty","Maud","maud","maul","Maun","maun","maux","mawk","mawp","Maya","maya","Mayo","maza","maze","mazy"
,"mead","meak","meal","mean","meat","Mede","meed","meek","meet","mein","meio","mela","meld","mele","mell"
,"melt","memo","mend","meng","Ment","menu","meny","mere","merk","merl","mero","mesa","mese","mesh","meso"
,"mess","meta","mete","Meum","mewl","mian","Miao","mias","mica","mice","Mick","mick","mico","mide","mids"
,"Miek","mien","miff","mijl","Mike","mike","Miki","mila","mild","mile","milk","mill","Milo","milo","milt"
,"mima","Mime","mime","Mimi","mimp","Mina","mina","mind","mine","Ming","ming","mink","mino","mint","minx"
,"miny","Mira","mird","mire","mirk","Miro","miro","miry","mise","miss","mist","mite","mitt","Mitu","mity"
,"Mixe","mixy","moan","moat","mock","mode","Moed","moff","mogo","moha","moho","mohr","moil","moio","moit"
,"Mojo","mojo","moke","moki","moko","moky","Mola","mola","mold","Mole","mole","Moll","moll","molt","moly"
,"mome","momo","mona","mone","mong","monk","Mono","mono","Mont","mood","mool","moon","moop","Moor","moor"
,"moot","mope","moph","mora","more","morg","morn","Moro","moro","mort","Mose","moss","most","mote","moth"
,"Mott","mott","moud","moul","moup","mout","move","mown","mowt","moxa","Moxo","moyo","much","muck","mudd"
,"muff","muga","mugg","muid","muir","mule","mulk","mull","mult","mump","mund","mung","munj","munt","Mura"
,"mura","mure","murk","Musa","Muse","muse","mush","musk","muss","must","muta","mute","muth","mutt","Muzo"
,"muzz","myal","myna","Myra","myst","myth","myxa","myxo","naam","nabk","nabs","Nabu","nace","nach","nael"
,"Naga","naga","naid","naif","naig","naik","nail","Naim","nain","naio","Nair","nais","Naja","nake","nako"
,"Nama","name","Nana","nana","nane","nant","Naos","naos","napa","nape","napu","nard","nark","narr","nary"
,"nash","nasi","nast","Nate","natr","Natt","naut","nave","navy","nawt","naze","Nazi","Neal","neal","neap"
,"near","neat","neck","need","neem","neep","neer","neet","neif","Neil","Nejd","Nell","nema","neon","Nepa"
,"Neri","nese","nesh","ness","nest","nete","neth","neti","neve","nevo","news","newt","next","ngai","Nhan"
,"Nias","nibs","Nice","nice","Nici","Nick","nick","nide","nidi","nife","nigh","Nile","Nils","nimb","Nina"
,"nine","Ning","niog","nipa","nito","Niue","nizy","Noah","Noam","nobs","nock","node","nodi","Noel","noel"
,"noil","noir","Noll","noll","nolo","noma","nome","Nona","none","nook","noon","noop","nope","Nora","nori"
,"Norm","norm","Norn","nose","nosh","Nosu","nosy","note","noun","noup","nous","nova","Novo","nowt","nowy"
,"noxa","Nozi","Nuba","Nuda","Nudd","nude","nuke","null","Numa","numb","Nupe","oaky","oary","oast","oath"
,"oaty","oban","obex","obey","obit","oboe","obol","ocht","odal","Odax","Odds","odds","odel","odic","Odin"
,"odor","odso","odum","odyl","Ofer","ogam","ogee","ogle","Ogor","Ogpu","ogre","ogum","ohia","Ohio","ohoy"
,"oily","oime","oint","okee","oket","okia","Okie","okra","Olaf","olam","Olax","Olea","Oleg","oleo","Olga"
,"olid","olio","olla","Olof","Olor","olpe","Oman","omao","Omar","omen","omer","omit","Onan","onca","once"
,"ondy","oner","only","onto","onus","onym","onyx","onza","oofy","ooid","oons","oont","oord","ooze","oozy"
,"opah","opal","open","opsy","opus","orad","oral","orby","Orca","ordu","orgy","orle","orlo","orna","Oryx"
,"osse","otic","Otis","Otto","otto","Otus","ouch","ough","ours","oust","oval","oven","over","ovey","Ovis"
,"ovum","Owen","ower","owly","owse","oxan","oxea","oxen","oxer","oxyl","oyer","Ozan","paal","paar","Paba"
,"paca","Pace","pace","pack","paco","pact","paga","Page","page","paha","pahi","paho","paik","pail","pain"
,"paip","pair","pais","Pala","pale","Pali","pali","pall","palm","palp","palt","paly","pand","pane","pang"
,"Pani","pank","pant","paon","papa","pape","para","pard","pare","pari","park","parr","Part","part","pash"
,"pasi","pass","past","pata","pate","path","pato","patu","paty","Paul","paup","paut","pave","Pavo","pavy"
,"pawk","pawl","pawn","peag","peai","peak","peal","pean","pear","peat","Peba","peba","pech","peck","peda"
,"peed","peek","peel","peen","peep","peer","pega","peho","Pele","pelf","pell","pelt","pelu","pend","penk"
,"pent","peon","pepo","peri","perk","perm","pern","pert","Peru","pesa","peso","pess","pest","Pete","pete"
,"peto","Petr","Peul","pewy","pfui","phew","Phil","phit","phiz","phoh","phon","phoo","phos","phot","phut"
,"pial","pian","Pica","pica","pice","Pici","pick","pico","Pict","pict","pied","pien","pier","Piet","piet"
,"piff","pika","pike","piki","piky","pile","pili","pill","pilm","pily","Pima","pimp","pina","pind","pine"
,"Ping","ping","pink","pino","pint","piny","pipa","pipe","pipi","pipy","pirl","pirn","Piro","pirr","pise"
,"pish","pisk","piso","piss","pist","pita","pith","pity","pixy","pize","plak","plan","plap","plat","play"
,"plea","pleb","pled","plew","plex","plim","plod","plop","plot","plow","ploy","plud","plug","plum","plup"
,"plus","pobs","pock","poco","poem","poet","Pogo","pogy","poha","poil","poke","poky","Pole","pole","polk"
,"Poll","poll","polo","polt","poly","pome","Pomo","pomp","pond","pone","pong","pont","pony","pooa","poof"
,"pooh","pook","pool","poon","poop","poor","poot","pope","pore","pork","porr","port","pory","pose","posh"
,"poss","post","posy","pote","pott","pouf","pour","pout","poxy","prad","pram","prat","prau","pray","prep"
,"prey","Pria","prig","prim","proa","prob","prod","prof","prog","proo","prop","prow","Prue","pruh","prut"
,"psha","puan","puce","puck","Pudu","pudu","puff","pugh","puja","puka","puke","puku","puky","pule","puli"
,"pulk","pull","pulp","pulu","puly","puma","Pume","pump","puna","pung","punk","Puno","punt","puny","pupa"
,"pure","purl","purr","Puru","push","puss","putt","puxy","Puya","pyal","pyic","pyin","pyke","pyla","pyre"
,"pyro","qere","qeri","qoph","quab","quad","quag","quan","quar","quat","quaw","quay","quei","quet","quey"
,"quib","quid","quin","quip","quis","quit","quiz","Qung","quod","quop","quot","raad","Rabi","race","rach"
,"rack","racy","rada","Rafe","raff","raft","raga","rage","Raia","raia","raid","Raif","rail","rain","Rais"
,"rais","Raja","raja","rake","rakh","raki","raku","rale","Ralf","Rama","rame","rami","ramp","Rana","rana"
,"Rand","rand","rane","rang","rani","rank","rann","rant","rape","rapt","rare","rasa","rase","rash","rasp"
,"rata","rate","rath","rauk","Raul","raun","rave","Ravi","raya","raze","razz","read","reak","Real","real"
,"ream","reap","rear","reck","rect","redd","rede","redo","reed","reef","reek","reel","reem","reen","Rees"
,"reet","reft","Reid","reif","reim","rein","reis","reit","Reki","rely","Remi","rend","renk","rent","Renu"
,"repp","reps","resh","resp","rest","Reub","reve","Rhea","rhea","Rhus","rial","ribe","rice","Rich","rich"
,"Rick","rick","ride","riem","rier","rife","Riff","riff","Rifi","rift","rikk","rile","rill","rima","rime"
,"rimu","rimy","Rind","rind","rine","ring","rink","riot","ripa","ripe","rise","risk","risp","Riss","rist"
,"Rita","rita","rite","riva","rive","rixy","road","roam","roan","roar","robe","rock","rodd","rode","roed"
,"roer","roey","roid","roil","roit","roka","roke","roky","role","Rolf","roll","Rome","romp","rond","rone"
,"Rong","rood","roof","rook","rool","room","roon","Root","root","rope","ropp","ropy","Rori","rory","Rosa"
,"rose","Ross","ross","rosy","rota","rote","roto","roub","roud","roue","roun","roup","rout","rove","rowy"
,"Roxy","roxy","royt","Rube","ruby","ruck","rudd","rude","Rudy","ruen","ruer","ruff","ruga","ruin","rukh"
,"rule","rull","rump","rune","rung","runt","rupa","ruru","Rusa","ruse","rush","rusk","Russ","rust","Ruta"
,"Ruth","ruth","ryal","ryen","ryme","rynd","rynt","ryot","rype","Saad","Saan","Saba","sabe","sack","saco"
,"sade","sadh","sado","Sadr","sadr","safe","Safi","saft","saga","sage","sago","sagy","sahh","Saho","saic"
,"said","sail","saim","sain","saip","sair","Saka","sake","saki","sale","Salm","salp","salt","same","samh"
,"samp","sand","sane","sang","sank","sans","sant","sapa","sapo","Sara","Sard","sard","sare","sari","sark"
,"Sart","sart","sasa","sash","sass","sate","sauf","Saul","saum","saur","saut","save","sawn","sawt","Saxe"
,"saya","scab","scad","scam","scan","scap","scar","scat","scaw","scho","scob","scog","Scot","scot","scow"
,"scry","scud","scug","scum","scun","scup","scur","scut","scye","scyt","seah","seak","seal","seam","Sean"
,"sear","seat","seax","Seba","sech","seck","sect","seed","seek","seel","seem","seen","seep","seer","sego"
,"Seid","seit","sele","self","sell","selt","seme","semi","send","sent","seps","Sept","sept","sera","Serb"
,"Sere","sere","serf","Seri","sero","sert","sess","seta","Seth","seth","sett","sewn","sext","sexy","Sgad"
,"shab","shad","shag","shah","Shai","Sham","sham","Shan","shan","shap","shat","Shaw","shaw","shay","shea"
,"shed","shee","Shel","Shen","sher","shih","Shik","shim","shin","ship","shiv","Shlu","Shoa","shod","shoe"
,"shog","shoo","shop","shoq","Shor","shor","shot","shou","show","shug","shul","shun","shut","siak","sial"
,"Siam","sice","sick","Sida","side","sidi","sidy","sier","sife","sift","sigh","sign","Sika","sika","sike"
,"Sikh","sile","silk","sill","silo","silt","sima","sime","simp","sina","sind","sine","sing","sinh","sink"
,"siol","Sion","sion","sipe","sire","sise","sish","sisi","siss","sist","Sita","site","sith","Sium","Siva"
,"siva","size","sizy","sizz","skag","skal","Skat","skat","skaw","skee","Skef","skeg","skel","sken","skeo"
,"skep","sker","skew","skey","skid","skil","skim","skin","Skip","skip","skit","skiv","skoo","skua","skun"
,"Skye","slab","slad","slae","slag","slam","slap","slat","Slav","slaw","slay","Sleb","sled","slee","slew"
,"sley","slid","slim","slip","slit","slob","slod","sloe","slog","slon","sloo","slop","slot","slow","slub"
,"slud","slue","slug","slum","slur","slut","smee","smew","smit","smog","smug","smur","smut","snab","snag"
,"snap","snaw","sneb","sned","snee","snew","snib","snig","snip","snob","snod","snog","snop","snot","Snow"
,"snow","snub","snug","snum","snup","snur","soak","soam","soap","soar","soce","sock","soco","soda","sody"
,"sofa","soft","Soga","soho","soil","Soja","soja","soka","soke","sola","sold","sole","soli","solo","soma"
,"some","sond","song","sonk","sons","sook","sool","soon","Soot","soot","sope","soph","sora","Sorb","sorb"
,"sore","sori","sorn","sort","sory","sosh","soso","soss","sots","soud","soul","soum","soup","sour","sowl"
,"sown","sowt","soya","spad","spae","spak","spam","span","Spar","spar","spat","spay","spec","sped","spet"
,"spew","spex","spig","spin","spit","spiv","spor","spot","spry","spud","spug","spun","spur","sput","stab"
,"stag","stam","Stan","stap","Star","star","staw","stay","steg","stem","sten","step","stet","stew","stey"
,"stib","stid","stim","stir","stoa","stob","stod","stof","stog","stop","stot","stow","stra","stre","stub"
,"stud","stue","stug","stum","stun","stut","Styx","such","suck","sudd","suds","suer","suet","suff","Sufi"
,"sugh","sugi","suid","suit","suji","Suku","Sula","suld","sulk","sull","Sulu","Sumo","sump","sune","Sung"
,"sung","sunk","sunn","sunt","supa","supe","sura","surd","sure","surf","susi","Susu","susu","Suto","Sutu"
,"suum","suwe","Suzy","Svan","Swab","swab","swad","swag","swam","swan","swap","Swat","swat","sway","swep"
,"swig","swim","swiz","swob","swom","swot","swow","swum","syce","Syed","sync","syne","syre","syrt","Syun"
,"Taal","taar","tabu","tach","tack","tact","tade","tael","taen","taft","taha","tahr","tail","tain","Tait"
,"tait","take","takt","Taku","taky","tala","talc","tald","tale","tali","talk","tall","Tama","Tame","tame"
,"tamp","tana","tane","Tang","tang","tanh","tank","Tano","Taos","Tapa","tapa","Tape","tape","taps","tapu"
,"tara","tare","tari","tarn","taro","tarp","tarr","tars","tart","tash","task","Tass","tass","tasu","tate"
,"tath","Tatu","tatu","taum","taun","taur","taut","Tave","tave","Tavy","tawa","tawn","taws","taxi","taxy"
,"tche","Tchi","tchu","tead","teak","teal","team","tean","teap","tear","teat","Tebu","Teca","teca","Tech"
,"tech","teck","Teco","Teda","teel","teem","teen","teer","teet","teff","teil","teju","tele","teli","tell"
,"telt","Tema","temp","tend","teng","tent","tera","Teri","term","tern","terp","Tess","test","tete","teth"
,"teuk","Tewa","text","Thad","Thai","than","thar","that","thaw","Thea","theb","thee","them","then","Theo"
,"thew","they","thig","thin","thio","thir","this","thob","thof","thon","thoo","Thos","thou","thow","thro"
,"thud","thug","thus","Tiam","tiao","tiar","tice","tick","tide","tidy","tied","tien","tier","tiff","tift"
,"tige","Tiki","tile","till","tilt","time","Timo","Tina","tind","tine","Ting","ting","tink","Tino","tint"
,"tiny","Tiou","tipe","tire","tirl","tirr","tite","titi","tivy","tiza","toad","Toag","toat","Toba","tobe"
,"Toby","toby","tock","toco","Toda","Todd","tode","tody","toed","toff","Toft","toft","tofu","toga","togs"
,"togt","toho","toil","toit","toke","toko","told","tole","toll","tolt","tolu","Toma","tomb","tome","tone"
,"tong","tonk","Tony","tony","took","tool","toom","toon","toop","toot","tope","toph","topi","topo","tops"
,"tora","torc","tore","torn","toro","tort","toru","Tory","tory","tosh","Tosk","toss","tost","tosy","tote"
,"toto","toty","toug","toup","tour","tout","towd","town","towy","toxa","toze","trag","trah","tram","Tran"
,"trap","tray","tree","tref","trek","tret","Trey","trey","trig","trim","trin","Trio","trio","trip","Trix"
,"trod","trog","tron","trot","trow","Troy","troy","trub","true","trug","trun","tryp","tryt","tsar","Tshi"
,"tsia","tsun","Tuan","tuan","Tuba","tuba","tube","tuck","tufa","tuff","tuft","tuik","tuke","tula","tule"
,"Tulu","tume","tump","Tuna","tuna","tund","tune","tung","tunk","tuno","tunu","tuny","Tupi","turb","turd"
,"turf","Turi","Turk","turk","turm","turn","turp","turr","Tush","tush","tusk","tute","tuth","tuts","tutu"
,"tuwi","tuza","twae","twal","twas","twat","tway","twee","twig","twin","twit","tyee","tyke","tymp","tynd"
,"type","typo","typp","typy","tyre","tyro","Tyrr","Tyto","uang","Ubii","Ucal","udal","Udic","ugly","uily"
,"Ulex","ulex","ulla","ulmo","ulna","Ulua","ulua","Ulva","umbo","umph","unal","unau","unbe","unca","unci"
,"unco","unde","undo","undy","unie","Unio","unio","unit","unto","untz","unze","upas","updo","upgo","upla"
,"upon","Ural","ural","Uran","uran","urao","urde","Urdu","urea","urge","Uria","uric","urna","Ursa","urus"
,"urva","usar","used","usee","user","Usun","Utah","utai","utas","utch","utum","uval","uvea","uvic","uvid"
,"uzan","vade","vady","vage","vail","vain","vair","vale","Vali","vali","vall","vamp","vane","vang","vara"
,"vare","vari","vary","Vasa","vasa","vase","vast","vasu","Vayu","veal","Veda","veen","veep","veer","Vega"
,"veil","vein","vela","vell","velo","Vend","vend","vent","Veps","vera","verb","verd","veri","Vern","vert"
,"very","vest","veta","veto","vext","vial","Vice","vice","Vick","vier","view","viga","vila","vile","Vili"
,"vill","vina","vine","vino","vint","viny","viol","Vira","vire","virl","visa","vise","vita","Viti","viva"
,"vive","vlei","voar","voet","void","vole","volt","vota","Vote","vote","vuln","Waac","waag","waar","wabe"
,"Wabi","wace","wack","Waco","Wade","wade","wadi","waeg","waer","Wafd","waff","waft","wage","waif","waik"
,"wail","wain","wait","waka","wake","wakf","waky","wale","wali","walk","wall","Walt","walt","wame","wamp"
,"wand","wane","wang","want","wany","wapp","ward","ware","warf","wark","warl","warm","warn","warp","wart"
,"wary","wase","wash","Wasp","wasp","wast","wath","watt","wauf","waul","waup","waur","Wave","wave","wavy"
,"wawa","waxy","ways","weak","weal","weam","wean","wear","wede","weed","week","weel","ween","weep","weet"
,"weft","Wega","weir","weka","weki","weld","Welf","welk","well","wels","welt","Wend","wend","wene","went"
,"wept","were","werf","weri","wert","wese","west","weta","weve","Wezn","wham","whan","whap","whar","what"
,"whau","whee","when","whet","whew","whey","whid","Whig","whig","whim","whin","whip","whir","Whit","whit"
,"whiz","whoa","whom","whoo","whop","whud","whun","whup","whuz","whyo","wice","wick","wide","widu","wife"
,"wild","wile","wilk","Will","will","wilt","wily","wime","wimp","Wind","wind","wine","wing","wink","wint"
,"winy","wipe","wips","wird","wire","wirl","wirr","wiry","wise","wish","wisp","wiss","wist","wite","with"
,"wive","woad","woak","woan","wode","woft","woke","wold","Wolf","wolf","womb","wone","wong","wont","wood"
,"woof","wool","woom","woon","wops","word","wore","work","worm","worn","wort","wote","wots","wouf","wove"
,"wowt","Wraf","wran","wrap","wraw","Wren","wren","wrig","writ","wrox","wudu","wugg","wulk","wull","wush"
,"wusp","wuss","wust","wuzu","wyde","wyke","wyle","wynd","wyne","wynn","wype","wyss","wyve","Xema","Xina"
,"Xipe","Xmas","Xosa","xyla","xyst","yaba","yabu","yade","yaff","yagi","yair","yaje","Yaka","yalb","Yale"
,"yale","yali","yamp","Yana","yang","yank","yapa","yapp","yarb","yard","yare","yark","yarl","yarm","yarn"
,"yarr","Yaru","yate","yati","yaud","yava","yawl","yawn","yawp","yaws","yawy","yaya","ycie","yday","yeah"
,"yean","year","yeat","yede","yeel","yees","yegg","yeld","yelk","yell","yelm","yelp","yelt","yeni","yerb"
,"yerd","yere","yerk","yern","yese","yeso","yest","yeta","yeth","yeuk","yigh","yill","yilt","yird","yirk"
,"yirm","yirn","yirr","yite","yobi","yock","yodh","yoga","yogh","yogi","yoke","yoky","yolk","yond","yont"
,"yook","yoop","yore","york","yote","youd","youl","youp","your","yowl","yowt","Yuan","yuan","yuca","yuck"
,"yuft","Yuga","Yuit","Yuki","yule","Yuma","yurt","yutu","Zach","zain","zant","zany","zarf","zarp","zati"
,"zeal","zebu","zeed","zein","Zeke","zemi","Zend","zenu","zero","zest","zeta","Zeus","zimb","zinc","zing"
,"zink","Zion","Zipa","Zips","zira","zizz","zobo","zoea","zogo","zoic","zoid","zoll","zone","zoom","zoon"
,"Zulu","Zuni","zuza","zyga","zyme"
    };

}

