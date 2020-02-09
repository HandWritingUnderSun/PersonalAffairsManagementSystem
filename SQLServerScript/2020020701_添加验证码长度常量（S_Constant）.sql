IF NOT EXISTS ( SELECT  *
            FROM    dbo.S_Constant
            WHERE   CName = 'checkcodelength' )
    BEGIN
        INSERT  INTO dbo.S_Constant
                ( CName ,
                  CValue ,
                  CDscp
                )
        VALUES  ( N'checkcodelength' , -- CName - nvarchar(50)
                  N'6' , -- CValue - nvarchar(2000)
                  N'验证码长度'  -- CDscp - nvarchar(200)
                );
    END;