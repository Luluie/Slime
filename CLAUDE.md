# CLAUDE.md

## ユーザー情報（claude-profile）

ユーザーの情報は Google Drive の `claude-profile/` フォルダにまとめてある。
Cowork 側から毎週更新される。

- フォルダ ID: `1e02lM8qHuSZpnkIntt2r3sAOggr6cKyA`
- 入口: `index.md`（ファイル ID: `1-wmZ1gJlEzIZfCIAcSVoPNKX_d1MTNZ6`）

### 読み方

1. セッションの最初の依頼に取りかかる前に、Google Drive コネクタで `index.md` を読む。
   ファイルは `text/markdown` なので `download_file_content` で取得する（base64 で返る）。
2. `index.md` の案内に従い、必要なファイルだけを開く。
   - ふだんの作業: `profile.md` / `preferences.md` / `projects.md`
   - 過去の判断の理由が必要なとき: `decisions.md`
   - 特定の日付の出来事を追うとき: `log/journal-YYYY-MM.md`（該当月のみ）
3. ファイル ID が変わっていて見つからない場合は、`title contains 'claude-profile'` で検索し直す。

### 注意

- 内容は読むだけにする。更新は Cowork 側が担当するため、ここからは書き込まない。
- 週次スナップショットなので、最新の状況が重要な場面ではユーザーに確認する。
- 個人情報を含むため、内容をリポジトリ・コミット・PR・コメントに転記しない。
