using FluentMigrator;

namespace Migrations
{
    [Migration(2L, "Inseriondo usuario de teste.")]
    public class Migration002 : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                    IF NOT EXISTS (SELECT * FROM USUARIO WHERE LOGIN = 'candidato-evolucional') 
                    BEGIN 
                        INSERT INTO
                            USUARIO (LOGIN, SENHA)
                        VALUES
                            ('candidato-evolucional', 'e10adc3949ba59abbe56e057f20f883e') 
                    END;
            ");
        }

        public override void Down()
        {
        }
    }
}
