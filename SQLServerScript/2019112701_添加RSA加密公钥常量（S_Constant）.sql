IF NOT EXISTS ( SELECT  *
                FROM    dbo.S_Constant
                WHERE   CName = 'RSA_Public_Key' )
    BEGIN
        INSERT  INTO dbo.S_Constant
                ( CName ,
                  CValue ,
                  CDscp
                )
        VALUES  ( N'RSA_Public_Key' , -- CName - nvarchar(50)
                  N'-----BEGIN PUBLIC KEY-----MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+2YhTMpKGgjc0hZ7Xt+EawtQWup6XXDiD4i9aa77JUjQkT2NNFgjrNQAdlRY1eD1xDK46boXYmIh7m/5CRCMN1oE/OY4/LGIwR6S4tNG3w3aWv9iIXmZ6cq5Z1tss+bFKX+7XNLZA3bMW+KYaigxFuQHhcWFFwTndwWVrn2zo/wIDAQAB-----END PUBLIC KEY-----' , -- CValue - nvarchar(2000)
                  N'RSAº”√‹π´‘ø'  -- CDscp - nvarchar(200)
                );
    END;
        
IF NOT EXISTS ( SELECT  *
                FROM    dbo.S_Constant
                WHERE   CName = 'RSA_Private_Key' )
    BEGIN
        INSERT  INTO dbo.S_Constant
                ( CName ,
                  CValue ,
                  CDscp
                )
        VALUES  ( N'RSA_Private_Key' , -- CName - nvarchar(50)
                  N'-----BEGIN RSA PRIVATE KEY-----MIICXQIBAAKBgQC+2YhTMpKGgjc0hZ7Xt+EawtQWup6XXDiD4i9aa77JUjQkT2NNFgjrNQAdlRY1eD1xDK46boXYmIh7m/5CRCMN1oE/OY4/LGIwR6S4tNG3w3aWv9iIXmZ6cq5Z1tss+bFKX+7XNLZA3bMW+KYaigxFuQHhcWFFwTndwWVrn2zo/wIDAQABAoGBALV7RhdXT954lOZs6c9YG8bG3cd/Tq/AEj3XKBBjxNjMQqkElPkIqxJ/I8z9qFDQNhz6YfNOhhihc6eXfwCkqm8luXaFYPoJBlAGSBKO1wXg0MnVwRtvVheMOZfV0tHYyHV56zvB92/9MNJE4IavOhJGDWmvQakecHW7y16JcFIBAkEA/kC50VHg5mfF8N/jCVhXDLqIkxBqk+i7rfNeVDcIjUxWwvN18H6YOVPzJxDV4JW9XseQDbBruQcjmF2/f9cujwJBAMApRREedzU3gLMUZEPq3bDsYqu3z8XzKwItybFk0Tu3HYlC7nS1pWcL7xVmbJ+7ibtv0cO8Dmonu+JvvSBg1pECQGlQUieb7LZDQcA2XIpgZx5EnZGc+Shu/F5fMjFb4lT0y/NQeQe2yELmvQ7vcEfoflol+0tQSi6IAHx6SHohnY0CQHVYfnHezeM0mqZBPJ1xDqJdKEA+xmXWghwZhAKNU2yI/UN2GRIyXuhXlE/YNVsx9gD9XvaNn6vZydWUcMUV/dECQQD7D3we/oO6RyDjMt4QHFkBY7bTzb+lfWtTD41Xef+BN4DXiJB8jLxot4byw737N/H1XOAqmgjOU165Y39lAutM-----END RSA PRIVATE KEY-----' , -- CValue - nvarchar(2000)
                  N'RSAº”√‹ÀΩ‘ø'  -- CDscp - nvarchar(200)
                );
    END;
        