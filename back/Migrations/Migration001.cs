using FluentMigrator;

namespace Migrations
{
    [Migration(1L, "Criação dos tabelas ALUNO, DISCIPLINA, ALUNO_DISCIPLINA e USUARIO")]
    public class Migration001 : Migration
    {
        public override void Up()
        {
            CriarTabelaAlunos();
            CriarTabelaDisciplinas();
            CriarTabelaAlunosDisciplinas();
            CriarTabelaUsuario();
        }

        private void CriarTabelaAlunos()
        {
            const string TABELA = "ALUNO";

            if (Schema.Table(TABELA).Exists())
                return;

            Create.Table(TABELA)
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("NOME").AsString(1000).NotNullable().Unique()
                .WithColumn("DATA_CRIACAO").AsDateTime().WithDefault(SystemMethods.CurrentDateTime).NotNullable();
        }

        private void CriarTabelaDisciplinas()
        {
            const string TABELA = "DISCIPLINA";

            if (Schema.Table(TABELA).Exists())
                return;

            Create.Table(TABELA)
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("DESCRICAO").AsString(1000).NotNullable()
                .WithColumn("CODIGO").AsString(100).NotNullable().Unique()
                .WithColumn("DATA_CRIACAO").AsDateTime().WithDefault(SystemMethods.CurrentDateTime).NotNullable();
        }

        private void CriarTabelaAlunosDisciplinas()
        {
            const string TABELA = "ALUNO_DISCIPLINA";

            if (Schema.Table(TABELA).Exists())
                return;

            Create.Table(TABELA)
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ALUNO_ID").AsInt32().NotNullable().ForeignKey("ALUNO", "ID")
                .WithColumn("DISCIPLINA_ID").AsInt32().NotNullable().ForeignKey("DISCIPLINA", "ID")
                .WithColumn("NOTA").AsDecimal(10, 2).NotNullable()
                .WithColumn("DATA_CRIACAO").AsDateTime().WithDefault(SystemMethods.CurrentDateTime).NotNullable();
        }

        private void CriarTabelaUsuario()
        {
            const string TABELA = "USUARIO";

            if (Schema.Table(TABELA).Exists())
                return;

            Create.Table(TABELA)
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("LOGIN").AsString().NotNullable().Unique()
                .WithColumn("SENHA").AsString().NotNullable()
                .WithColumn("DATA_CRIACAO").AsDateTime().WithDefault(SystemMethods.CurrentDateTime).NotNullable();
        }

        public override void Down()
        {
        }
    }
}
