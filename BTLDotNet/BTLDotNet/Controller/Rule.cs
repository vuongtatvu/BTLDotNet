using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLDotNet.Controller
{
    class Rule
    {
        public virtual bool IsValid(string x)
        {
            return true;
        }

        public virtual string Explain()
        {
            return "";
        }
    }
    //kiểm tra từ tối đa có 7 chữ cái
    class Rule1 : Rule
    {
        public override bool IsValid(string x)
        {
            if (x.Length > 7)
            {
                return false;
            }
            return true;
        }

        public override string Explain()
        {
            return "Số chữ không thể lớn hơn 7 trong 1 từ ";
        }
    }

    //kiem tra có wjzf
    class Rule2 : Rule
    {
        public override bool IsValid(string x)
        {
            string wrongChars = "wjzf";
            for (int j = 0; j < x.Length; j++)
            {
                if (wrongChars.Contains("" + x[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ không thể chứa w j z f ";
        }
    }


    // Một số cặp phụ âm chỉ được phép đứng đầu từ.
    class Rule3 : Rule
    {
        public override bool IsValid(string x)
        {

            string allConsonants = "bcdđghklmnpqtvxrs";
            if (x.Length >= 3)
                //kiểm tra xem từ có chứa 2 phụ âm ở đầu hay không
                if (allConsonants.Contains(x[0]) && allConsonants.Contains(x[1]))
                {
                    //kiểm tra xem 2 phụ âm đó có được phép đứng cạnh nhau k
                    string[] pairs = { "th", "tr", "ch", "ph", "kh", "nh", "gh", "ng" };
                    foreach (var p in pairs)
                    {
                        if (x.StartsWith(p))
                            return true;
                    }
                    return false;
                }
            return true;
        }

        public override string Explain()
        {
            return "Sai cặp phụ âm đứng đầu";
        }
    }

    //cặp phụ âm 3 đứng đầu "ngh"
    class Rule3_2 : Rule
    {
        public override bool IsValid(string x)
        {
            string allConsonants = "bcdđghklmnpqtvxrs";
            if (x.Length >= 4)
            {
                //kiểm tra xem từ có 3 phụ âm đứng đầu hay không
                if (allConsonants.Contains(x[0]) && allConsonants.Contains(x[1])
                    && allConsonants.Contains(x[2]))
                {
                    //từ có 3 phụ âm đứng đầu thì phải là "ngh"
                    if (!x.StartsWith("ngh"))
                        return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Sai phụ âm đứng đầu";
        }
    }

    /* Phụ âm cuối
     * Một số phụ âm ĐƠN vào ĐÔI được phép đứng cuối  */
    class Rule4 : Rule
    {
        public override bool IsValid(string x)
        {
            string allConsonants = "bcdđghklmnpqtvxrs";
            string[] pairs = { "nh", "ch", "ng" };
            string[] single = { "c", "m", "n", "p", "t" };
            if (x.Length >= 3)
            {
                //kiểm tra từ kết thúc bởi 2 phụ âm
                if (allConsonants.Contains(x[x.Length - 1]) && allConsonants.Contains(x[x.Length - 2]))
                {
                    foreach (var p in pairs)
                    {
                        if (x.EndsWith(p))
                            return true;
                    }
                    return false;
                }
                //nếu không phải 2 phụ âm đứng cuối
                //thì kiểm tra 1 phụ âm đứng cuối cùng 
                else if (allConsonants.Contains(x[x.Length - 1]))
                {
                    foreach (var s in single)
                    {
                        if (x.EndsWith(s))
                            return true;
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Sai phụ âm đứng cuối";
        }
    }

    //- Một từ tiếng Việt có tối đa 5 phụ âm
    class Rule5 : Rule
    {
        public override bool IsValid(string x)
        {
            int dem = 0;
            string phuAm = "qrtpsdghklxcvbnmđ";
            for (int j = 0; j < x.Length; j++)
            {
                if (phuAm.Contains(x[j]))
                {
                    dem++;
                    if (dem > 5)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ quá 5 phụ âm!";
        }
    }

    // Một từ có tối đa 3 nguyên âm.
    class Rule6 : Rule
    {
        public override bool IsValid(string x)
        {
            int dem = 0;
            string nguyenAm = "aáàãạâấầẫậăắằặẵiíìịĩyýỳỵỹeéèẹẽêếềệễoóóọõôôồôỗơớớợỡuúùụũưứũựữ";
            for (int i = 0; i < x.Length; i++)
            {
                if (nguyenAm.Contains(x[i]))
                {
                    dem++;
                    if (dem > 3)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ quá 3 nguyên âm!";
        }
    }

    // "K, Gh, Ngh" khi đứng trước i/y, iê, ê, e (kí/ký, kiêng, kệ, kẻ);
    class Rule7 : Rule
    {
        string nguyenAm = "aáàãạâấầẫậăắằặẵiíìịĩyýỳỵỹeéèẹẽêếềệễoóóọõôôồôỗơớớợỡuúùụũưứũựữ";
        string nguyenAmDiSau = "iíìịĩyýỳỵỹeéèẹẽêếềệễ";
        public override bool IsValid(string x)
        {
            if (x.Length >= 2)
            {
                if (x[0].Equals("k") && nguyenAm.Contains(x[1]))
                {
                    if (!nguyenAmDiSau.Contains(x[1]))
                        return false;
                }
            }

            if (x.Length >= 3)
            {
                if (x.StartsWith("gh") && nguyenAm.Contains(x[2]))
                {
                    if (!nguyenAmDiSau.Contains(x[2]))
                        return false;
                }
            }

            if (x.Length >= 4)
            {
                if (x.StartsWith("ngh") && nguyenAm.Contains(x[3]))
                {
                    if (!nguyenAmDiSau.Contains(x[3]))
                        return false;
                }
            }

            return true;
        }

        public override string Explain()
        {
            return "Bắt đầu bằng K, Gh, NGh phải đi với i/y, iê, ê, e";
        }
    }

    //cuối cùng là c,t,p thì dấu là sắc , nặng 
    class Rule8 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] thanhSacNang = {"á","ạ","ắ","ặ","ấ","ậ","é","ẹ","ế","ệ",
                                     "ó","ọ","ớ","ợ","ố","ộ","ú","ụ","ứ","ự","í","ị","ý","ỵ"};
            if (x.EndsWith("c") || x.EndsWith("p") || x.EndsWith("t"))
            {
                foreach (string thanh in thanhSacNang)
                {
                    if (x.Contains(thanh))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ có chữ cái cuối cùng là c, t, p thì dấu là sắc , nặng !";
        }
    }

    //1 từ không thể vừa chứa số vừa chứa chữ
    class Rule9 : Rule
    {
        public override bool IsValid(string x)
        {
            int demChu = 0, demSo = 0;
            string so = "0123456789";
            string chu = "qrtpsdđghklxcvbnmaáàãạảâấầẫậẩăắằặẵẳiíìịĩỉyýỳỵỹỷeéèẹẻẽêếềệễểoóòọỏõôốồộỗổơờớợỡởuúùụũủưứừựữử";
            for (int i = 0; i < x.Length; i++)
            {
                if (so.Contains(x[i]))
                {
                    demSo++;
                    if (demChu != 0 && demSo != 0)
                    {
                        return false;
                    }
                }
                if (chu.Contains(x[i]))
                {
                    demChu++;
                    if (demChu != 0 && demSo != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string Explain()
        {
            return "Từ không thể vừa chứa số vừa chứa chữ";
        }
    }

    //Từ chứa ít nhất 1 nguyên âm
    class Rule10 : Rule
    {
        public override bool IsValid(string x)
        {
            string so = "0123456789";
            string nguyenam = "aáàãạảâấầẫậẩăắằặẵẳiíìịĩỉyýỳỵỹỷeéèẹẻẽêếềệễểoóòọỏõôốồộỗổơờớợỡởuúùụũủưứừựữử";
            int demChu = 0;
            int demSo = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (nguyenam.Contains(x[i]))
                {
                    demChu++;
                }
                if (so.Contains(x[i]))
                {
                    demSo++;
                }
            }
            if (demChu == 0 && demSo != x.Length)
            {
                return false;
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ phải có ít nhất 1 nguyên âm";
        }
    }

    // Nếu từ đó độ  dài là 1 thì là nguyên âm
    class Rule11 : Rule
    {
        public override bool IsValid(string x)
        {
            string nguyenam = "aáàãạảâấầẫậẩăắằặẵẳiíìịĩỉyýỳỵỹỷeéèẹẻẽêếềệễểoóòọỏõôốồộỗổơờớợỡởuúùụũủưứừựữử0123456789";
            if (x.Length == 1)
            {
                if (!nguyenam.Contains(x))
                {
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Từ này không thể đừng riêng lẻ được";
        }
    }

    // Kiểm tra 2 thanh điệu trở lên
    class Rule12 : Rule
    {
        public override bool IsValid(string x)
        {
            string thanhDieu = "áàãạảấầẫậẩắằặẵẳíìịĩỉýỳỵỹỷéèẹẻẽếềệễểóòọỏõốồộỗổờớợỡởúùụũủứừựữử";

            int dem = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (thanhDieu.Contains(x[i]))
                {
                    dem++;
                    if (dem > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "1 từ không thể có 2 thanh điệu";
        }
    }

    class Rule13 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van = {
                  "a", "á", "à", "ả", "ạ", "ã", "ác", "ạc", "ách", "ạch", "ai", "ái", 
                  "ài", "ãi", "ải", "ại", "am", "ám", "àm", "ãm", "ảm", "ạm", "an", "án",
                  "àn", "ãn", "ản", "ạn", "ang", "áng", "àng", "ãng", "ảng", "ạng", "anh",
                  "ánh", "ành", "ãnh", "ảnh", "ạnh", "ao", "áo", "ào", "ão", "ảo", "ạo", "áp",
                  "ạp", "át", "ạt", "au", "áu", "àu", "ãu", "ảu", "ay", "áy", "ày", "ạy", "ảy",
                  "ạy", "ắc", "ặc", "ăm", "ắm", "ằm", "ẵm", "ẳm", "ặm", "ăn", "ắn", "ằn", "ẵn",
                  "ẳn", "ặn", "ăng", "ắng", "ằng", "ẵng", "ẳng", "ặng", "ắp", "ặp", "ắt", "ặt", 
                  "ấc", "ậc", "âm", "ấm", "ầm", "ẩm", "ẫm", "ậm", "ân", "ấn", "ần", "ẩn", "ẫn",
                  "ận", "âng", "ấng", "ầng", "ẩng", "ẫng", "ậng", "ấp", "ập", "ất", "ật", "âu",
                  "ấu", "ầu", "ẩu", "ẫu", "ậu", "ây", "ấy", "ầy", "ẩy", "ẫy", "ậy" ,
                  "o","ó","ò","ỏ","õ","ọ","óc","ọc","oi","ói","òi","ỏi","õi","ọi","om","óm",
                  "òm","ỏm","õm","ọm","on","ón","òn","ỏn","õn","ọn","ong","óng","òng","ỏng",
                  "õng","ọng","óp","ọp","ót","ọt","oong","oóc","oọc","óoc","ọoc", 
                  "ơ","ớ","ờ","ở","ỡ","ợ","ơi","ới","ời","ởi","ỡi","ợi","ơm","ớm","ờm",
                  "ởm","ỡm","ợm","ơn","ớn","ờn","ởn","ỡn","ợn","ớp","ợp","ớt","ợt"
                  ,"ui","úi","ùi","ủi","ụi","ũi"
                            };
            string[] phuAmDau = {
                   "","b","c","ch","d","đ","g","h","kh","l","m",
                   "n","ng","nh","ph","r","s","t","th","tr","v","x" 
                                };

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    if (x.StartsWith("qu"))
                    {
                        return true;
                    }
                    foreach (string z in phuAmDau)
                    {

                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }
    }

    class Rule14 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={
                   "e","é","è","ẻ","ẽ","ẹ","éc","ẹc","em","ém","èm","ẻm","ẽm",
                   "ẹm","en","én","èn","ẻn","ẽn","ẹn","eng","éng","èng","ẻng",
                   "ẽng","ẹng","eo","éo","èo","ẻo","ẽo","ẹo","ép","ẹp","ét","ẹt",
                   "ê","ế","ề","ể","ễ","ệ","ếch","ệch","ênh","ếnh","ềnh","ểnh",
                   "ễnh","ệnh","êm","ếm","ềm","ểm","ễm","ệm","ên","ến","ền","ển",
                   "ễn","ện","ếp","ệp","ết","ệt","êu","ếu","ều","ểu","ễu","ệu","i",
                   "í","ì","ỉ","ĩ","ị","ích","ịch","im","ím","ìm","ỉm","ĩm","ịm","in",
                   "ín","ìn","ỉn","ĩn","ịn","inh","ính","ình","ỉnh","ĩnh","ịnh","íp",
                   "ịp","ít","ịt","iu","íu","ìu","ỉu","ĩu","ịu","ia","ía","ìa","ỉa",
                   "ĩa","ịa","iếc","iệc","iêm","iếm","iềm","iểm","iễm","iệm","iên",
                   "iến","iền","iển","iễn","iện","iêng","iếng","iềng","iểng","iễng",
                   "iệng","iếp","iệp","iết","iệt","iêu","iếu","iều","iểu","iễu","iệu"
                     };

            string[] phuAmDau = {
                   "","b","ch","d","đ","gh","g","h","k","kh","l","m","n","ngh","nh",
                   "ph","r","s","t","th","tr","v","x" 
                                };

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    if (x.ToLower().StartsWith("qu"))
                    {
                        return true;
                    }
                    foreach (string z in phuAmDau)
                    {

                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }
    }

    class Rule15 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={
                    "oa","óa","òa","ỏa","õa","ọa","oác","oạc","oách","oạch","oai",
                    "óai","òai","ỏai","õai","ọai","oan","oán","oàn","oản","oãn","oạn",
                    "oang","oáng","oàng","oảng","oãng","oạng","oanh","oánh","oành","oảnh",
                    "oãnh","oạnh","oáp","oạp","oát","oạt","oay","oáy","oày","oảy","oãy",
                    "oạy","oắc","oặc","oăn","oắn","oằn","oẳn","oẵn","oặn","oăng","oắng",
                    "oằng","oẳng","oẵng","oặng","oắt","oặt","oe","óe","òe","ỏe","õe","ọe",
                    "oét","oẹt"
                        };

            string[] phuAmDau = {
                   "","b","ch","d","đ","g","h","kh","l","m","n","ng","nh",
                   "ph","r","s","t","th","tr","v","x"           
                  };

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    foreach (string z in phuAmDau)
                    {
                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }
    }

    class Rule16 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={
                    "ua","úa","ùa","ủa","ụa","ũa","uốc","uộc","uôi","uối","uồi","uổi",
                    "uội","uỗi","uôm","uốm","uồm","uổm","uộm","uỗm","uôn","uốn","uồn",
                    "uổn","uộn","uỗn","uông","uống","uồng","uổng","uộng","uỗng","uốt","uột",
                    "uây","uấy","uầy","uẩy","uẩy","uẫy","uân","uấn","uần","uẩn",
                   "uận","uẫn","uâng","uất","uật","uê","uế","uề","uể","uệ","uễ","uênh",
                   "uếnh","uềnh","uểnh","uệnh","uễnh","uếch","uệch","uy","úy","ùy","ủy",
                   "ụy","ũy","uých","uỵch","uynh","uýnh","uỳnh","uỷnh","uỵnh","uỹnh","uýt",
                   "uỵt","uyn","úyn","uýp","uỵp","uya","uyên","uyến","uyền","uyển","uyện",
                   "uyễn","uyết","uyệt"
                   };

            string[] phuAmDau = {
                    "", "b", "c", "ch", "d", "đ", "g", "h", "kh", "l", "m", "n", 
                    "ng", "nh", "ph", "q", "r", "s", "t", "th", "tr", "v", "x"
                  };

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    foreach (string z in phuAmDau)
                    {
                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }

    }

    class Rule17 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={
                      "yếm","yểm","yêng","yếng","yềng","yểng","yệng","yễng","yết","yệt",
                      "yêu","yếu","yều","yểu","yệu","yễu"
                   };

            string[] phuAmDau = {""};

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    foreach (string z in phuAmDau)
                    {
                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }

    }

    class Rule18 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={"y","ý","ỳ","ỷ","ỵ","ỹ"};

            string[] phuAmDau = {"", "h", "k", "l", "m", "t"};

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    if (x.ToLower().StartsWith("qu"))
                    {
                        return true;
                    }
                   
                    foreach (string z in phuAmDau)
                    {

                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }

    }

    class Rule19 : Rule
    {
        public override bool IsValid(string x)
        {
            string[] van ={
                   "ô","ố","ồ","ổ","ỗ","ộ","ôc","ốc","ồc","ổc","ỗc","ộc","ôi",
                   "ối","ồi","ổi","ỗi","ội","ôm","ốm","ồm","ổm","ỗm","ộm","ôn",
                   "ốn","ồn","ổn","ỗn","ộn","ông","ống","ồng","ổng","ỗng","ộng",
                   "ốp","ộp","ốt","ột","u","ú","ù","ủ","ụ","ũ","úc","ục","um","úm",
                   "ùm","ủm","ụm","ũm","un","ún","ùn",
                   "ủn","ụn","ũn","ung","úng","ùng","ủng","ụng","ũng","úp","ụp","út",
                   "ụt","ư","ứ","ừ","ử","ự","ữ","ức","ực","ưi","ứi","ừi",
                   "ửi","ựi","ữi","ưu","ứu","ừu","ửu","ựu","ữu","ưng","ứng","ừng","ửng",
                   "ựng","ững","ứt","ựt","ưm","ứm","ừm","ửm","ựm","ữm","ưa","ứa","ừa","ửa",
                   "ựa","ữa","ước","ược","ươi","ưới","ười","ưởi","ượi","ưỡi","ươm","ướm",
                   "ườm","ưởm","ượm","ưỡm","ươn","ướn","ườn","ưởn","ượn","ưỡn","ương",
                   "ướng","ường","ưởng","ượng","ưỡng","ướp","ượp","ướt","ượt","ươu","ướu",
                   "ườu","ưởu","ưỡu","ượu"
                   };

            string[] phuAmDau = {
                "", "b", "c", "ch", "d", "đ", "g", "h", "kh", "l", "m", "n",
                "ng", "nh", "ph", "r", "s", "t", "th", "tr", "v", "x"
                  };

            string vanCuaTu = NoiDung.Van(x);
            string phuAmDauCuaTu = NoiDung.PhuAmDau(x);

            foreach (string y in van)
            {
                if (y.Equals(vanCuaTu))
                {
                    foreach (string z in phuAmDau)
                    {
                        if (z.Equals(phuAmDauCuaTu))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "Phụ âm đầu không được viết với vần này";
        }
    }
    //2 nguyen am giong nhau tru oo la sai
    class Rule20 : Rule
    {
        public override bool IsValid(string x)
        {
        string[] van ={
        "aa","aá","aà","aã","aạ","aả","aâ","aấ","aầ","aẫ","aậ","aẩ","aă","aắ","aằ","aặ","aẵ",
        "aẳ","aí","aì","aị","aĩ","aỉ","aý","aỳ","aỵ","aỹ","aỷ","ae","aé","aè","aẹ","aẻ","aẽ",
        "aê","aế","aề","aệ","aễ","aể","aó","aò","aọ","aỏ","aõ","aô","aố","aồ","aộ","aỗ","aổ",
        "aơ","aờ","aớ","aợ","aỡ","aở","aú","aù","aụ","aũ","aủ","aư","aứ","aừ","aự","aữ","aử",
        "âa","âá","âà","âã","âạ","âả","ââ","âấ","âầ","âẫ","âậ","âẩ","âă","âắ","âằ","âặ","âẵ",
        "âẳ","âi","âí","âì","âị","âĩ","âỉ","âý","âỳ","âỵ","âỹ","âỷ","âe","âé","âè","âẹ","âẻ",
        "âẽ","âê","âế","âề","âệ","âễ","âể","âo","âó","âò","âọ","âỏ","âõ","âô","âố","âồ","âộ",
        "âỗ","âổ","âơ","âờ","âớ","âợ","âỡ","âở","âú","âù","âụ","âũ","âủ","âư","âứ","âừ","âự",
        "âữ","âử","ăa","ăá","ăà","ăã","ăạ","ăả","ăâ","ăấ","ăầ","ăẫ","ăậ","ăẩ","ăă","ăắ","ăằ",
        "ăặ","ăẵ","ăẳ","ăi","ăí","ăì","ăị","ăĩ","ăỉ","ăy","ăý","ăỳ","ăỵ","ăỹ","ăỷ","ăe","ăé",
        "ăè","ăẹ","ăẻ","ăẽ","ăê","ăế","ăề","ăệ","ăễ","ăể","ăo","ăó","ăò","ăọ","ăỏ","ăõ","ăô",
        "ăố","ăồ","ăộ","ăỗ","ăổ","ăơ","ăờ","ăớ","ăợ","ăỡ","ăở","ău","ăú","ăù","ăụ","ăũ","ăủ",
        "ăư","ăứ","ăừ","ăự","ăữ","ăử","ii","ií","iì","iị","iĩ","iỉ","iy","iý","iỳ","iỵ","iỹ",
        "iỷ","iử","yá","yà","yã","yạ","yả","yâ","yấ","yầ","yẫ","yậ","yẩ","yă","yắ","yằ","yặ",
        "yẵ","yẳ","yi","yí","yì","yị","yĩ","yỉ","yy","yý","yỳ","yỵ","yỹ","yỷ","ye","yé","yè",
        "yẹ","yẻ","yẽ","yo","yó","yò","yọ","yỏ","yõ","yô","yố","yồ","yộ","yỗ","yổ","yơ","yờ",
        "yớ","yợ","yỡ","yở","yu","yú","yù","yụ","yũ","yủ","yư","yứ","yừ","yự","yữ","yử","ea",
        "eá","eà","eã","eạ","eả","eâ","eấ","eầ","eẫ","eậ","eẩ","eă","eắ","eằ","eặ","eẵ","eẳ",
        "ei","eí","eì","eị","eĩ","eỉ","ey","eý","eỳ","eỵ","eỹ","eỷ","ee","eé","eè","eẹ","eẻ",
        "eẽ","eê","eế","eề","eệ","eễ","eể","eó","eò","eọ","eỏ","eõ","eô","eố","eồ","eộ","eỗ",
        "eổ","eơ","eờ","eớ","eợ","eỡ","eở","eu","eú","eù","eụ","eũ","eủ","eư","eứ","eừ","eự",
        "eữ","eử","êa","êá","êà","êã","êạ","êả","êâ","êấ","êầ","êẫ","êậ","êẩ","êă","êắ","êằ",
        "êặ","êẵ","êẳ","êi","êí","êì","êị","êĩ","êỉ","êy","êý","êỳ","êỵ","êỹ","êỷ","êe","êé",
        "êè","êẹ","êẻ","êẽ","êê","êế","êề","êệ","êễ","êể","êo","êó","êò","êọ","êỏ","êõ","êô",
        "êố","êồ","êộ","êỗ","êổ","êơ","êờ","êớ","êợ","êỡ","êở","êú","êù","êụ","êũ","êủ","êư",
        "êứ","êừ","êự","êữ","êử","oâ","oấ","oầ","oẫ","oậ","oẩ","oí","oì","oị","oĩ","oỉ","oy",
        "oý","oỳ","oỵ","oỹ","oỷ","oè","oẻ","oẽ","oê","oế","oề","oệ","oễ","oể","oò","oỏ","oõ",
        "oô","oố","oồ","oộ","oỗ","oổ","oơ","oờ","oớ","oợ","oỡ","oở","ou","oú","où","oụ","oũ",
        "oủ","oư","oứ","oừ","oự","oữ","oử","ôa","ôá","ôà","ôã","ôạ","ôả","ôâ","ôấ","ôầ","ôẫ",
        "ôậ","ôẩ","ôă","ôắ","ôằ","ôặ","ôẵ","ôẳ","ôí","ôì","ôị","ôĩ","ôỉ","ôy","ôý","ôỳ","ôỵ",
        "ôỹ","ôỷ","ôe","ôé","ôè","ôẹ","ôẻ","ôẽ","ôê","ôế","ôề","ôệ","ôễ","ôể","ôo","ôó","ôò",
        "ôọ","ôỏ","ôõ","ôô","ôố","ôồ","ôộ","ôỗ","ôổ","ôơ","ôờ","ôớ","ôợ","ôỡ","ôở","ôu","ôú",
        "ôù","ôụ","ôũ","ôủ","ôư","ôứ","ôừ","ôự","ôữ","ôử","ơa","ơá","ơà","ơã","ơạ","ơả","ơâ",
        "ơấ","ơầ","ơẫ","ơậ","ơẩ","ơă","ơắ","ơằ","ơặ","ơẵ","ơẳ","ơí","ơì","ơị","ơĩ","ơỉ","ơy",
        "ơý","ơỳ","ơỵ","ơỹ","ơỷ","ơe","ơé","ơè","ơẹ","ơẻ","ơẽ","ơê","ơế","ơề","ơệ","ơễ","ơể",
        "ơo","ơó","ơò","ơọ","ơỏ","ơõ","ơô","ơố","ơồ","ơộ","ơỗ","ơổ","ơơ","ơờ","ơớ","ơợ","ơỡ",
        "ơở","ơú","ơù","ơụ","ơũ","ơủ","ơư","ơứ","ơừ","ơự","ơữ","ơử","uí","uì","uị","uĩ","uỉ",
        "uo","uó","uò","uọ","uỏ","uõ","uu","uú","uù","uụ","uũ","uủ","uư","uứ","uừ","uự","uữ",
        "uử","ưá","ưà","ưã","ưạ","ưả","ưâ","ưấ","ưầ","ưẫ","ưậ","ưẩ","ưă","ưắ","ưằ","ưặ","ưẵ",
        "ưẳ","ưi","ưí","ưì","ưị","ưĩ","ưỉ","ưy","ưý","ưỳ","ưỵ","ưỹ","ưỷ","ưe","ưé","ưè","ưẹ",
        "ưẻ","ưẽ","ưê","ưế","ưề","ưệ","ưễ","ưể","ưo","ưó","ưò","ưọ","ưỏ","ưõ","ưô","ưố","ưồ",
        "ưộ","ưỗ","ưổ","ưú","ưù","ưụ","ưũ","ưủ","ưư","ưứ","ưừ","ưự","ưữ","ưử","áa","áâ","áă",
        "áe","áê","áô","áơ","áư","àa","àâ","àă","àe","àê","àô","àơ","àư","ãa","ãâ","ãă","ãe",
        "ãê","ãô","ãơ","ãư","ạa","ạâ","ạă","ạe","ạê","ạô","ạơ","ạư","ảa","ảâ","ảă","ảe","ảê",
        "ảô","ảơ","ảư","ấa","ấâ","ấă","ấi","ấe","ấê","ấo","ấô","ấơ","ấư","ầa","ầâ","ầă","ầi",
        "ầe","ầê","ầo","ầô","ầơ","ầư","ẫa","ẫâ","ẫă","ẫi","ẫe","ẫê","ẫo","ẫô","ẫơ","ẫư","ậa",
        "ậâ","ậă","ậi","ậe","ậê","ậo","ậô","ậơ","ậư","ẩa","ẩâ","ẩă","ẩi","ẩe","ẩê","ẩo","ẩô",
        "ẩơ","ẩư","ắa","ắâ","ắă","ắi","ắy","ắe","ắê","ắo","ắô","ắơ","ắu","ắư","ằa","ằâ","ằă",
        "ằi","ằy","ằe","ằê","ằo","ằô","ằơ","ằu","ằư","ặa","ặâ","ặă","ặi","ặy","ặe","ặê","ặo",
        "ặô","ặơ","ặu","ặư","ẵa","ẵâ","ẵă","ẵi","ẵy","ẵe","ẵê","ẵo","ẵô","ẵơ","ẵu","ẵư","ẳa",
        "ẳâ","ẳă","ẳi","ẳy","ẳe","ẳê","ẳo","ẳô","ẳơ","ẳu","ẳư","íâ","íă","íi","íy","íe","íê",
        "ío","íô","íơ","íư","ìâ","ìă","ìi","ìy","ìe","ìê","ìo","ìô","ìơ","ìư","ịâ","ịă","ịi",
        "ịy","ịe","ịê","ịo","ịô","ịơ","ịư","ĩâ","ĩă","ĩi","ĩy","ĩe","ĩê","ĩo","ĩô","ĩơ","ĩư",
        "ỉâ","ỉă","ỉi","ỉy","ỉe","ỉê","ỉo","ỉô","ỉơ","ỉư","ýa","ýâ","ýă","ýi","ýy","ýe","ýê",
        "ýo","ýô","ýơ","ýu","ýư","ỳa","ỳâ","ỳă","ỳi","ỳy","ỳe","ỳê","ỳo","ỳô","ỳơ","ỳu","ỳư",
        "ỵa","ỵâ","ỵă","ỵi","ỵy","ỵe","ỵê","ỵo","ỵô","ỵơ","ỵu","ỵư","ỹa","ỹâ","ỹă","ỹi","ỹy",
        "ỹe","ỹê","ỹo","ỹô","ỹơ","ỹu","ỹư","ỷa","ỷâ","ỷă","ỷi","ỷy","ỷe","ỷê","ỷo","ỷô","ỷơ",
        "ỷư","éa","éâ","éă","éi","éy","ée","éê","éô","éơ","éu","éư","èa","èâ","èă","èi","èy",
        "èe","èê","èô","èơ","èu","èư","ẹa","ẹâ","ẹă","ẹi","ẹy","ẹe","ẹê","ẹô","ẹơ","ẹu","ẹư",
        "ẻa","ẻâ","ẻă","ẻi","ẻy","ẻe","ẻê","ẻô","ẻơ","ẻu","ẻư","ẽa","ẽâ","ẽă","ẽi","ẽy","ẽe",
        "ẽê","ẽô","ẽơ","ẽu","ẽư","ếa","ếâ","ếă","ếi","ếy","ếe","ếê","ếo","ếô","ếơ","ếư","ềa",
        "ềâ","ềă","ềi","ềy","ềe","ềê","ềo","ềô","ềơ","ềư","ệa","ệâ","ệă","ệi","ệy","ệe","ệê",
        "ệo","ệô","ệơ","ệư","ễa","ễâ","ễă","ễi","ễy","ễe","ễê","ễo","ễô","ễơ","ễư","ểa","ểâ",
        "ểă","ểi","ểy","ểe","ểê","ểo","ểô","ểơ","ểư","óâ","óă","óy","óê","óô","óơ","óu","óư",
        "òâ","òă","òy","òê","òo","òô","òơ","òu","òư","ọâ","ọă","ọy","ọê","ọô","ọơ","ọu","ọư",
        "ỏâ","ỏă","ỏy","ỏê","ỏo","ỏô","ỏơ","ỏu","ỏư","õâ","õă","õy","õê","õo","õô","õơ","õu",
        "õư","ốa","ốâ","ốă","ốy","ốe","ốê","ốo","ốô","ốơ","ốu","ốư","ồa","ồâ","ồă","ồy","ồe",
        "ồê","ồo","ồô","ồơ","ồu","ồư","ộa","ộâ","ộă","ộy","ộe","ộê","ộo","ộô","ộơ","ộu","ộư",
        "ỗa","ỗâ","ỗă","ỗy","ỗe","ỗê","ỗo","ỗô","ỗơ","ỗu","ỗư","ổa","ổâ","ổă","ổy","ổe","ổê",
        "ổo","ổô","ổơ","ổu","ổư","ờa","ờâ","ờă","ờy","ờe","ờê","ờo","ờô","ờơ","ờư","ớa","ớâ",
        "ớă","ớy","ớe","ớê","ớo","ớô","ớơ","ớư","ợa","ợâ","ợă","ợy","ợe","ợê","ợo","ợô","ợơ",
        "ợư","ỡa","ỡâ","ỡă","ỡy","ỡe","ỡê","ỡo","ỡô","ỡơ","ỡư","ởa","ởâ","ởă","ởy","ởe","ởê",
        "ởo","ởô","ởơ","ởư","úâ","úă","úe","úê","úo","úô","úơ","úu","úư","ùâ","ùă","ùe","ùê",
        "ùo","ùô","ùơ","ùu","ùư","ụâ","ụă","ụe","ụê","ụo","ụô","ụơ","ụu","ụư","ũâ","ũă","ũe",
        "ũê","ũo","ũô","ũơ","ũu","ũư","ủâ","ủă","ủe","ủê","ủo","ủô","ủơ","ủu","ủư","ứâ","ứă",
        "ứy","ứe","ứê","ứo","ứô","ứơ","ứư","ừâ","ừă","ừy","ừe","ừê","ừo","ừô","ừơ","ừư","ựâ",
        "ựă","ựy","ựe","ựê","ựo","ựô","ựơ","ựư","ữâ","ữă","ữy","ữe","ữê","ữo","ữô","ữơ","ữư",
        "ửâ","ửă","ửy","ửe","ửê","ửo","ửô","ửơ" ,"ửư"
                   };

   

            foreach (string y in van)
            {
                if (x.Contains(y))
                {
                    return false;
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "2 nguyên âm giống nhau không thể đi với nhau hoặc để sai dấu";
        }
    }

    //Cac từ sai vị trí thanh điệu
}