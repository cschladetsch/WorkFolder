# Technical Policy

[christian@schladetsch.com](mailto:christian@schladetsch.com)

This document is issued for free commercial and non-commercial use under the [MIT](https://opensource.org/licenses/MIT) License.

If you make generally good changes, it is hoped that you will push them back.

## Abstract

This document prescribes a set of policies to follow when going about daily technical work within a multiple-disciplinary technical team.

It also serves a guide for third-party users of such systems.

Lastly, it has a free _MIT_ license so it can be used as a basis for other companies that do not have any such documentation.

## Version History

| Version | Notes |
| --- | --- |
| 0.2 | Peer reviewed & published. |
| 0.4 | Add numbered references to clauses. |
| 0.5 | Simplified Abstract and Introduction text, new recursive Glossary, added and refined terms. |
| 0.6 | Made publicly editable. |
| 0.7 | Made public. |
| 0.8 | Converted to Markdown. |

## Glossary

| Term | Meaning |
| --- | --- |
| _May_ | May be followed and should not be flagged. |
| _Must_ | Must be followed and should be flagged. |
| _Required_ | Required to be followed and required to be flagged. |
| _Should_ | Should be followed and may be flagged. |

If _May/Must/Required/Should_ is omitted from a policy term, then it is considered as _Must_.

Terms starting with &quot;Do&quot; or &quot;Do not&quot; are considered as _Must_.

_Must_ becomes _Should,_ and _Required_ becomes _May_ in relation to third-party sources.

## Introduction

This is the canonical standards document for how things are created, stored and referenced.

Standards such as these help reduce communication error, inform developers on how to make decisions regarding technicalities like naming conventions and project structure, and ease transition across projects.

You may use this document as a reference when asking for a change to be made by another developer, especially when reviewing code via a _Pull Request_.

Everyone in the company - or anywhere else - is free to edit this document. Just be ready to defend any such change.

These rules apply only for internal development purposes.

## 1. General
There are some common rules that apply in all cases:
1. Bullet points should start with a capital and end with punctuation.
1. Must add new clauses or sub-clauses at the end of any list in this document.
	<u>Rationale</u>: Existing references to clauses must not break due to reformatting of this source text.
1. Should use correct English: e.g. Realise rather than Realize, etc. Consider your language usage.
1. All general documents must be stored on [_GoogleDocs_](http://docs.google.com).
1. Should not use spaces or any punctuation in any file-name or object-name.
	1. Such names should consist of alpha-numeric characters only, starting with a non-numeric character, and use UpperCamelCase.
4. Technical documentation should be concise and correct.
	1. Update older documentation when things change.
	2. Internal documents stored in any git repository must use [_MarkDown_](https://en.wikipedia.org/wiki/Markdown).
6. Should provide links whenever you can. Read about how to add links to GoogleDocs and MarkDown.
6. Should use _Italics_ when referring to companies or when initially referring to some external library or technology like [_Microsoft .Net_](https://dotnet.microsoft.com/).
	1. Should also use this as a link.
7. Do not repeat yourself.
	1. Use links to refer to other [documentation](https://docs.google.com/document/d/1w4MYPKsW-Prj6z9XlJjeuN-h4Fbtoas38aWgHTlMEjg/edit#).
9. _GoogleDocs_ should use the default font: Arial 11-pt.
9. Should use fixed-width fonts, preferably Courier New 11pt, when referring to
	1. Files.
	2. [_Unity3d_](http://www.unity3d.com) Object names.
	3. Script names or script contents, or
	4. git branch names.
	5. When using Markdown, use \``backticks`\` around such items.
12. Should not use any underscores, dashes, spaces, or full stops in any names.
12. Acronyms such as ABC should be spelled Abc.
	1. Note that SI units are not acronyms. So, to indicate mega-bytes, it is correct to say &quot;MB&quot; and incorrect to say &quot;Mb&quot; - which is a different thing.
14. Do not use emoticons or curse in any formal writing, including code or scripts, or when communicating with clients.
15. Should use indicative and consistent avatar images across all platforms, like _Trello_, _Slack_, _GitHub_, _Gmail_ etc.
15. Text files should be UTF-8, UTF-16, or ASCII encoded, in that order of preference.
	1. Must not use UNICODE for anything.
17. Line endings on all files created or used by [_Windows_](https://www.microsoft.com/en-au/windows)must use \r\n line-endings.
18. Line endings on all [_Linux_](https://www.linux.org/)- or [_macOS_](https://www.apple.com/au/macos/)-based text files must end with \n.
19. Should use [WorkFolder](https://github.com/cschladetsch/WorkFolder) system.
19. Must use [_Iso-8601_](https://en.wikipedia.org/wiki/ISO_8601) for dates and times.
	1. Store all date-time values as [_Utc_](https://en.wikipedia.org/wiki/Coordinated_Universal_Time). Do not use local time, which may include daylight savings. At Melbourne, Australia we are typically Utc+11.
	2. YY-MM-DD for dates.
	3. YY-MM-DDTHH-mm-ss for date and time for filenames.
	4. Note that Americans use MM-DD-YY. This is wrong and it causes confusion.
21. Internal copyright notices must be of the form _© [year] [Company] Pty Ltd._
22. Do not include any whitespace at the ends of any text lines, except a newline sequence.
22. Should use [_IEC_](https://en.wikipedia.org/wiki/International_Electrotechnical_Commission) binary prefixes for base-2 quantities and [_SI_](https://en.wikipedia.org/wiki/International_System_of_Units) prefixes for base-10 quantities.
	<u>Rationale</u>: Disambiguation. See [Mebibyte](https://en.wikipedia.org/wiki/Mebibyte). Basically, if you mean 1000 bytes, say a kilobyte (KB). If you mean 2^10 or 1024 bytes, say [kibibyte](https://www.google.com/search?q=kibibyte) (KiB).
24. When referencing a policy item from this document, use e.g. §1.2.3. The section symbol § is available by:
    1. Windows: Alt+0167 or Alt+21
    2. MacOS: ⌥ Option+6
    3. iOS: & (long press) 

## 2. Unity3d

The current state of _Unity3d_, especially as it relates to Vr, is chaotic. This is not expected to change as new hardware and software is rapidly introduced.

Even so, many entire companies are based on Unity3d. We have to manage this complexity collectively.

To that end:

1. Must consult your lead before making a new project.
1. Do not use random assets from e.g. [_Asset Store_](https://assetstore.unity.com/) without first contacting your lead.
1. Third-party files must live wherever causes the least harm.
1. Do not include _Examples_ or _Tests_ from any third-party library or package in any first-party repo.
	1. Modify `.gitignore` if you want them locally.
	2. Do include a md that points to original asset including any samples etc.
5. Must use `/w/bin/new-project` to make a new project.
1. Application source files (specific to current application) must live in `Assets/App ` folder.
7. Scenes live in `Assets/Scenes`.
8. Should include a *Markdown* `Readme.md` file in every major folder that briefly describes the purpose and contents of that folder.
9. Internal libraries are supplied as Unity3d [_Packages_](https://docs.unity3d.com/Manual/Packages.html).
  1. Use `master` branch for all such internal packages.
10. Do not call objects in the scene or prefabs _GameObject_.
11. Should Learn _bash_, _vi_ and _git_ from the command-line.

## 3. Git

Using [git](https://git-scm.com/) is considered a part of professional competency **.** You should feel comfortable to use it without breaking things - just as much as using _Maya_ or _PhotoShop_ or _Visual Studio_ or _Unity3d_.

Thankfully, there's a worm-hole within git itself. What makes it so hard to use means you can't really irrevocably break anything or lose work unless you go out of your way and do things you do not understand.

At least read about [git stash](https://git-scm.com/book/en/v1/Git-Tools-Stashing) if you're unsure about things. Yes, this is extra thought and knowledge required from you.

Git is assuredly complicated. There are ways to make it easier to use:

1. `master` branch must always build and run.
	1. Do not touch `master` branch.
1. `develop` branch should always build and run.
1. Do not do things you do not understand.
	1. Be very careful with `git rebase`.
1. Should use [git-flow](https://www.google.com/search?q=git+flow).
	1. `git flow init`
1. Must use [git-lfs](https://git-lfs.github.com/).
	1. `git lfs install`
	2. Alternatively, use `git-lfs-install`, available via _WorkFolder_, which will install Lfs and also add tracking of common binary files such as Tga, Jpg, Fbx, etc.
1. Should branch from `develop`.
  1. You can branch from a specific branch using git-flow: `git-flow -b source-branch my-branch`.
	1. The default source branch is `develop`.
	1. Do not branch from `master`.
1. Do not make any changes to any git work-flow without discussing with Cto first.
1. Must not touch `master` branch.
	1. The only thing to do on `master` is either merge from `develop` if you're team lead, or
	1. Make a hotfix that goes through a _Pull Request_.
	1. As a corollary, the git log for `master` must only have merge, tag and hotfix commits.
	1. This excludes Unity3d Packages which anyone can pull `master`.
	1. Package development is only done by leads on develop or _git-flow_ branches from `develop`.
1. Must go through a peer-reviewed _Pull Request_ when merging to develop.
	1. Except for changes to scene or prefabs, then it's a should.
1. Do what you want on branches other than develop or master.
	1. You can share branches! Just pull someone else's branch.
1. Must use `lower-dashed-case` for git branch names.
1. Always merge develop before you make a PR.
1. To make a _Pull Request_, say
	1. `λ mpr`
	1. Or, browse to https://github.com/**[company]**/**[repo-name]**/pull/new/develop
1. How to do this via a Gui is left up to you.
1. Do not make PRs to `master`. Team leads will deal with with `master`.
1. As a reviewer, you should first pull the branch under review and ensure it builds and runs locally.

## 5. Maya/Modelling

1. Must use 1 unit = 1 meter.
1. Must export using [_Left-handed Coordinates_](https://www.evl.uic.edu/ralph/508S98/coordinates.html)
	1. Right is +x, Up is +y, Forward is +z.
1. Should Must use [.fbx](https://en.wikipedia.org/wiki/FBX) for source.
1. Items should must import and work without needing to be scaled/rotated/offset Unity3d-side.

## 6. Photoshop/Images

1. Should use [.png](https://en.wikipedia.org/wiki/Portable_Network_Graphics) for source images.
1. Must use [ASTC Compression](https://en.wikipedia.org/wiki/Adaptive_Scalable_Texture_Compression) for import.
	1. If in doubt, default to 4x4 compression.
	1. Note that 4x4 is smaller (more compressed/noisy) than 8x8 etc.
1. Should not include `.psd` files as assets in Unity3d.
	1. Break out components into separate well-named assets.

## 7. Audio

1. Should use lossless format for source audio, such as [Flac](https://en.wikipedia.org/wiki/FLAC) or very high 320+bps compressed.
2. Must use [.ogg](https://xiph.org/vorbis/) for import.

## 8. C#

See reference code.

For example of style requirements, see other canonical repositories like [Flow](https://github.com/cschladetsch/Flow). Note that these are a living breathing libraries, so there will be some inconsistencies.

Feel free to correct any problems and submit a _Pull Request_.

1. All coders should use [_ReSharper Pro_](https://www.jetbrains.com/resharper/).

2. Must use spaces rather than tab characters.

  1. Tab must be 4 spaces.
     <u>Rationale</u>: Consistent readability across all platforms and editors, both local and remote, such as GitHub Pull Requests.
     
  4. You will be fired if you mix tabs and spaces in the same file.

4. If a given code-line has over 90 characters, it should be wrapped.
     1. If it has over 110 it must be wrapped.
   <u>Rationale</u>: Readability within the context of a vertically-split tab in _Visual Studio_.
   
5. Do read other internal code bases.
   <u>Rationale</u>: Learn the specs.
   
6. Do follow syntax and formatting conventions used in any file you modify, even if doing so contravenes conventions stated in this document.
     1. If it&#39;s an internal file, follow convention of the local file and make a separate PR for the formatting change.
   <u>Rationale</u>: Commits should be atomic. Separate logical changes/additions from formatting changes.
   
7. Do use your intuition after reading common libraries such as [Flow](https://github.com/cschladetsch/Flow).
   <u>Rationale</u>: I am not going to write pages and pages of explicit instructions about how to write and format every aspect of C# code.
   The standards for C#, and C# itself, changes over time, so that is a pointless endeavor in any case.
   Read existing code and always follow conventions around any changes you make, even if they contradict what is in this document.
   
8. Do not make arbitrary formatting changes which pollute the git commit history.
     1. Put these in a new commit called &quot;Reformatting&quot;.
     2. Such commits must not change any logic.
     
9. Should provide complexity guarantees using [_big-O notation_](https://en.wikipedia.org/wiki/Big_O_notation) for all properties or methods that are prefixed with _Calc_.
   <u>Rationale</u>: Allows a developer to know what he&#39;s in for.
   
10. Namespaces must use UpperCamelCase.
    <u>Rationale</u>: Consistency in naming.
    
11. Assemblies that may be consumed by other projects must use a unique top-level namespace.
    <u>Rationale</u>: If an assembly is not consumed by another project, it doesn&#39;t matter what namespace it uses. Conversely, it does matter.
    
13. All symbols should be in a namespace.

13. All public classes, interfaces, delegates, and enumerations in an assembly must have [_Xml comments_](https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-xml-documentation-comments?view=vs-2019).
    <u>Rationale</u>: Provide more information to the reader.
    
14. All other public symbols should also have Xml Comments.
    <u>Rationale</u>: Provide more information to the reader. Also will help any automation tools used to produce documentation.
    
15. **Enumerations** must start with the letter &#39;E&#39;.
    <u>Rationale</u>: Makes it clear to the reader that the given symbol name is an Enumeration type.
    
16.  **Interfaces** must start with the letter &#39;I&#39; (capital-i).
    <u>Rationale</u>: Makes it clear to the reader that the given symbol name is an Interface type.
    
17.  **Public** methods must use UpperCamelCase in verb-noun form.
      1. `GetFoo` implies either a fast lookup or an immediate return.
      1. `CalcFoo` implies that work has to be done to get a result.
Do not use a property that does much work every time it is referenced.
      1. `FetchFoo` implies that work _may_ be done to get a result.
     
19. **Protected** fields must use \_UnderUpperCamelCase.

20. **Private** fields must use \_underLowerCamelCase.

21. **Arguments and local variables** must use lowerCamelCase.

22. **Constant/Static** fields must use the same conventions as above.

21. All expression bodies must go on the next line.
	
	1. Longer expressions must use a code-block.
	
  24. Stops situations like: one method has an expression body on same line, the next one has an expression body on the next line, the next has a code block.

25. Should May use braces {} on single-line code-blocks.

26. Must add a space after keywords.

27. No spaces around multiplicative operators like \* and /.

28. Space around additive operators like + and -.

29. Group expressions in parentheses if evaluation order is not clear.

30. Must use [Allman-style](http://syque.com/cstyle/ch6.7.htm) braces.

28. Do not curse or use disparaging remarks or slang or emotes in code or comments.
    `// wtf is this shit :( ← um, no.`
    
32. Should not commit commented-out code.

30. Sentences in log messages and comments should end with a full-stop.
    <u>Rationale</u>: This makes it clear when the message has correctly ended and was not abruptly terminated.
    
34. Do not use a property that does much work every time it is referenced.

32. All `usings` must be within a namespace.
    <u>Rationale</u>: This avoids any ambiguity early.
    
33. Add a newline after a code block or `var` statement sequence.
    <u>Rationale</u>: Consistency.
    
37. Must not have empty newlines in empty blocks.

35. Should not have newlines in `using` sequences.
    <u>Rationale</u>: Save vertical whitespace.

**Finis**