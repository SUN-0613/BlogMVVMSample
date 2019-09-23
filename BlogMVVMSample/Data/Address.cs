namespace BlogMVVMSample.Data
{

    /// <summary>住所クラス</summary>
    public class Address
    {

        /// <summary>郵便番号</summary>
        public string PostalCode { get; set; }

        /// <summary>都道府県</summary>
        public string Prefectures { get; set; }

        /// <summary>市区町村</summary>
        public string City { get; set; }

        /// <summary>地名</summary>
        public string Place { get; set; }

    }

}