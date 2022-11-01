STARTUP_PROJECT := TestePratico.Web
DATA_PROJECT := TestePratico.Data
MIGRATION_NAME :=

.PHONY: start-web
start-web:
	dotnet run --project ./$(STARTUP_PROJECT);

.PHONY: watch-web
watch-web:
	dotnet watch --project ./$(STARTUP_PROJECT);

.PHONY: add-migration
add-migration:
    # ifndef MIGRATION_NAME
    #     $(error MIGRATION_NAME must be defined)
    # endif;

	cd $(STARTUP_PROJECT) && \
	dotnet ef migrations add "$(MIGRATION_NAME)" \
		--project=../$(DATA_PROJECT) \
		--output-dir=../$(DATA_PROJECT)/Migrations;

.PHONY: remove-migration
remove-migration:
	cd $(STARTUP_PROJECT) && \
	dotnet ef migrations remove --project ../$(DATA_PROJECT);

.PHONY: update-database
update-database:
	cd $(STARTUP_PROJECT) && \
	dotnet ef database update --project ../$(DATA_PROJECT);

.PHONY: drop-database
drop-database:
	cd $(STARTUP_PROJECT) && \
	dotnet ef database drop --project ../$(DATA_PROJECT);
