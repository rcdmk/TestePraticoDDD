STARTUP_PROJECT := TestePratico.Web
SERVICES_PROJECT := TestePratico.Services
DATA_PROJECT := TestePratico.Data
MIGRATION_NAME :=

.PHONY: echo
echo:
	@echo "MIGRATION_NAME: $(MIGRATION_NAME)";

.PHONY: start-web
start-web:
	dotnet run --project ./$(STARTUP_PROJECT);

.PHONY: watch-web
watch-web:
	dotnet watch --project ./$(STARTUP_PROJECT);

.PHONY: start-services
start-services:
	dotnet run --project ./$(SERVICES_PROJECT);

.PHONY: watch-services
watch-services:
	dotnet watch --project ./$(SERVICES_PROJECT);

.PHONY: add-migration
add-migration:
	@test -n "$(MIGRATION_NAME)" || (echo "MIGRATION_NAME must be defined" ; exit 1);

	cd $(STARTUP_PROJECT) && \
	dotnet ef migrations add "$(MIGRATION_NAME)" \
		--project=../$(DATA_PROJECT) \
		--output-dir=../$(DATA_PROJECT)/Migrations;

.PHONY: remove-migration
remove-migration:
	cd $(STARTUP_PROJECT) && \
	dotnet ef migrations remove --project ../$(DATA_PROJECT);

.PHONY: revert-to-migration
revert-to-migration:
	@test -n "$(MIGRATION_NAME)" || (echo "MIGRATION_NAME must be defined" ; exit 1);

	cd $(STARTUP_PROJECT) && \
	dotnet ef database update "$(MIGRATION_NAME)" \
		--project=../$(DATA_PROJECT);


.PHONY: update-database
update-database:
	cd $(STARTUP_PROJECT) && \
	dotnet ef database update --project ../$(DATA_PROJECT);

.PHONY: drop-database
drop-database:
	cd $(STARTUP_PROJECT) && \
	dotnet ef database drop --project ../$(DATA_PROJECT);

.PHONY: tests
tests:
	dotnet test
