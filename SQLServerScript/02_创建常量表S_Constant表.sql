----����ϵͳ����S_Constant��
IF NOT  EXISTS ( SELECT  name
            FROM    sys.tables
            WHERE   name = 'S_Constant'  and type='U')
BEGIN    
CREATE TABLE [dbo].[S_Constant]
    (
      [CName] [NVARCHAR](50) COLLATE Chinese_PRC_CI_AS
                             NOT NULL
                             PRIMARY KEY ,
      [CValue] [NVARCHAR](2000) COLLATE Chinese_PRC_CI_AS
                                NOT  NULL ,
      [CDscp] [NVARCHAR](200) COLLATE Chinese_PRC_CI_AS
                              NULL
    )
--ALTER TABLE ���� WITH NOCHECK ADD
--CONSTRAINT [PK_����] PRIMARY KEY NONCLUSTERED
--(
--CNAME
--);
--GO
END 