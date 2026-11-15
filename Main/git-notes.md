# Git notes

## Task 15 — Basic git

### Commands
- Инициализация репозитория (через интерфейс VS, аналог `git init`)
- Создание коммитов (аналог `git commit -m "..."`)
- Создание ветки `feature/git-basics` (аналог `git branch` + `git checkout`)
- Слияние ветки в `main` (аналог `git merge`)
- Разрешение конфликта (ручное удаление маркеров и `git add` + `git commit`)

### Output (git log --graph --oneline --all)
* merge: task 15 - resolve conflict
* fix: task 15 - change in main to cause conflict
* feat: task 15 - change in feature branch
* docs: task 15 - add second line
* feat: task 15 - initial commit

### What I learned
Я научился создавать локальный репозиторий, делать коммиты, создавать ветки и, самое главное, разрешать конфликты слияния вручную. Понял, что `git add` нужен перед коммитом, когда правишь конфликт.

## Task 35
### Rebase result
Выполнена команда `git rebase -i HEAD~3`.
В редакторе три коммита были объединены (squash) в один.
Итоговый лог после rebase:

* dd36cb3 (HEAD -> feature/rebase-demo, origin/feature/rebase-demo) feat: combined commits for rebase demo
* e76b6cf (origin/level-2, level-2) chore: add gitignore and editorconfig
* 0ba4e5b feat: task 34 - linq word grouping
* 7cd1f60 feat: task 33 - linq employees queries
* 7731464 feat: task 32 - temperature with validation



## Task 48 — git tags
### Commands
- `git tag -a v1.0.0 -m "Release v1.0.0"`
- `git push origin v1.0.0`
- `git tag`
- `git show v1.0.0`

### Output (git show v1.0.0)
tag v1.0.0
Tagger: Gnom <saxnov0707@mail.ru>
Date:   Sun Nov 15 03:27:50 2026 +0300

Release v1.0.0

commit 4480d99697dc3e81b9b3e7e4fe546adf8afafd33 (HEAD -> main, tag: v1.0.0, origin/master, origin/level-2, origin/feature/rebase-demo, origin/HEAD, level-2, feature/rebase-demo)
Author: Gnom <saxnov0707@mail.ru>
Date:   Sat Nov 14 05:29:23 2026 +0300

    docs: task 35 - update git notes

diff --git a/Main/git-notes.md b/Main/git-notes.md
index c94528e..c30e3cc 100644
--- a/Main/git-notes.md
+++ b/Main/git-notes.md
@@ -25,8 +25,8 @@
 В редакторе три коммита были объединены (squash) в один.
 Итоговый лог после rebase:

-dd36cb3 (HEAD -> feature/rebase-demo, origin/feature/rebase-demo) feat: combined commits for rebase demo
-e76b6cf (origin/level-2, level-2) chore: add gitignore and editorconfig
-0ba4e5b feat: task 34 - linq word grouping
-7cd1f60 feat: task 33 - linq employees queries
-7731464 feat: task 32 - temperature with validation
+* dd36cb3 (HEAD -> feature/rebase-demo, origin/feature/rebase-demo) feat: combined commits for rebase demo
+* e76b6cf (origin/level-2, level-2) chore: add gitignore and editorconfig
+* 0ba4e5b feat: task 34 - linq word grouping
+* 7cd1f60 feat: task 33 - linq employees queries
+* 7731464 feat: task 32 - temperature with validation
