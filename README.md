Banco de Dados - CandyHill

- Restauração da Base

1. Acesse o **SQL Server Management Studio (SSMS)** conectado ao container `sqlserver`.

2. Faça o **restore** do backup:
   - Vá em *Databases > Restore Database...*
   - Escolha o arquivo `CandyHill.bak` (presente na pasta `/db` ou no repositório)

3. Após o restore, a base **CandyHill** estará disponível e a API poderá ser acessada normalmente.

---

**Importante:**
- O volume `candyhillweb_sql_data` é **local** — ele não é versionado nem enviado ao GitHub.
- Cada desenvolvedor que clonar o projeto deverá restaurar o banco uma vez.
